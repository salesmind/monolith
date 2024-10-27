using Microsoft.Extensions.Configuration;
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
        builder.Services.AddInfrastructure(appSettings);
        return builder;
    }
}
