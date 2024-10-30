using Microsoft.EntityFrameworkCore;
using SalesMind.Application.Queries;
using SalesMind.Infrastructure;
using SalesMind.Infrastructure.Data;

namespace SalesMind.API;
public static class MigrateTenantDbContextExtensions
{

    public static IServiceCollection AddTenantMigration(this IServiceCollection services, Func<TenantDbContext, IServiceProvider, Task> seeder)
    {
        return services.AddHostedService(sp => new TenantMigrationHostedService(sp, seeder));
    }

    public static IServiceCollection AddTenantMigration(this IServiceCollection services)
        => services.AddTenantMigration((_, _) => Task.CompletedTask);

    public static IServiceCollection AddTenantMigration<TDbSeeder>(this IServiceCollection services)
        where TDbSeeder : class, IDbSeeder<TenantDbContext>
    {
        services.AddScoped<IDbSeeder<TenantDbContext>, TDbSeeder>();
        return services.AddTenantMigration((context, sp) => sp.GetRequiredService<IDbSeeder<TenantDbContext>>().SeedAsync(context));
    }


    private class TenantMigrationHostedService(IServiceProvider serviceProvider, Func<TenantDbContext, IServiceProvider, Task> seeder) : BackgroundService
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return serviceProvider.MigrateTenantDbContextAsync(seeder);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
    private static async Task MigrateTenantDbContextAsync(this IServiceProvider services, Func<TenantDbContext, IServiceProvider, Task> seeder) 
    {
        using var scope = services.CreateScope();
        var scopeServices = scope.ServiceProvider;
        var tenantQueries = scopeServices.GetRequiredService<ITenantQueries>();
        var dbProvider = scopeServices.GetRequiredService<ITenantDbProvider>();
        var tenants = await tenantQueries.GetTenantsAsync();
        var logger = scopeServices.GetRequiredService<ILogger<ITenantDbProvider>>();

        try
        {
            logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TenantDbContext).Name);
            foreach (var tenant in tenants)
            {
                using var context = dbProvider.GetOrCreate(tenant.Id);
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(() => InvokeSeeder(seeder, context, scopeServices));
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TenantDbContext).Name);

            throw;
        }
    }
    private static async Task InvokeSeeder(Func<TenantDbContext, IServiceProvider, Task> seeder, TenantDbContext context, IServiceProvider services)
    {
        await context.Database.MigrateAsync();
        await seeder(context, services);
    }
}
