using Microsoft.Extensions.DependencyInjection;
using SalesMind.Application.Queries;

namespace SalesMind.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        return services
             .AddAutoMapper(assembly)
             .AddMediatR(config =>
             {
                 config.RegisterServicesFromAssemblies(assembly);
             })
             .AddQueries();
    }

    private static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<ITenantQueries, TenantQueries>();
        services.AddScoped<ICustomerQueries, CustomerQueries>();
        return services;
    }

}
