using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesMind.Infrastructure.Configurations;

namespace SalesMind.Infrastructure.Data;
public class TenantDbProvider(IOptions<AppSettings> options, IMediator mediator = null) : ITenantDbProvider
{
    private readonly AppSettings _appSettings = options.Value;
    public TenantDbContext GetOrCreate(Guid tenantId)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql(_appSettings.TenantDbConnection, options =>
        {
            options.EnableRetryOnFailure(3);
        });
        return new TenantDbContext(optionsBuilder.Options, tenantId.ToString(), mediator);
    }
}
