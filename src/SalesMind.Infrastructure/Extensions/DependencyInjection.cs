using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesMind.Infrastructure.Caching;
using SalesMind.Infrastructure.Configurations;
using SalesMind.Infrastructure.Data;
using StackExchange.Redis;

namespace SalesMind.Infrastructure.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, AppSettings appSettings)
    {
        return services
             .AddSingleton(appSettings)
             .AddDbContexts(appSettings)
             .AddCaching(appSettings);
    }
    private static IServiceCollection AddDbContexts(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddScoped<ITenantDbProvider, TenantDbProvider>();

        services.AddDbContext<SharedDbContext>(options =>
        {
            options.UseNpgsql(appSettings.SharedDbConnection, sql =>
            {
                sql.EnableRetryOnFailure(3);
            });
        }, ServiceLifetime.Scoped);
        return services;
    }

    private static IServiceCollection AddCaching(this IServiceCollection services, AppSettings appSettings)
    {
        if (string.IsNullOrEmpty(appSettings.RedisConnection))
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, InMemoryCacheManager>();
        }
        else
        {
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(appSettings.RedisConnection));
            services.AddScoped<ICacheManager, RedisCacheManager>();
        }
        return services;
    }
}
