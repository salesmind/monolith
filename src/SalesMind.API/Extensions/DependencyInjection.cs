using Microsoft.Extensions.Configuration;
using SalesMind.API.Infrastructure.Services;
using SalesMind.API.Setup;
using SalesMind.Application;
using SalesMind.Application.Services;
using SalesMind.Infrastructure;
using SalesMind.Infrastructure.Configurations;
using SalesMind.Infrastructure.Extensions;

namespace SalesMind.API;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddApplicationService(this WebApplicationBuilder builder)
    {
        var appSettings = new AppSettings
        {
            RedisConnection = builder.Configuration.GetConnectionString("Redis"),
            SharedDbConnection = builder.Configuration.GetConnectionString("Shared"),
            TenantDbConnection = builder.Configuration.GetConnectionString("Tenant")
        };
        builder.Services
            .AddInfrastructure(appSettings)
            .AddApplication()
            .AddMigration<SharedDbContext>((db, sp) => new SharedDbSeeder(sp).SeedAsync(db))
            .AddTenantMigration()
            .AddHttpContexts();
        return builder;
    }
    private static IServiceCollection AddHttpContexts(this IServiceCollection services){
        
        services.AddHttpContextAccessor();
        services.AddTransient<IUserContext, HttpUserContext>();
        return services;
    }
}
