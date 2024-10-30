using System.Collections.Concurrent;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesMind.Infrastructure.Configurations;

namespace SalesMind.Infrastructure.Data;
public class TenantDbProvider(AppSettings appSettings, IMediator mediator = null) : ITenantDbProvider
{
    private readonly AppSettings _appSettings = appSettings;
    private readonly ConcurrentDictionary<Guid, TenantDbContext> _tenantDbContextCache = [];
    public ConcurrentDictionary<Guid, TenantDbContext> TenantDbContexts => _tenantDbContextCache;

    public void Dispose()
    {
        foreach (var tenantDbContext in TenantDbContexts)
        {
            tenantDbContext.Value.Dispose();
        }
    }
    public TenantDbContext GetOrCreate(Guid tenantId)
    {
        return TenantDbContexts.GetOrAdd(tenantId, Create(tenantId));
    }
    public TenantDbContext Create(Guid tenantId)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql(_appSettings.TenantDbConnection, options =>
        {
            options.EnableRetryOnFailure(3);
        });
        return new TenantDbContext(optionsBuilder.Options, tenantId.ToString(), mediator);
    }
}
