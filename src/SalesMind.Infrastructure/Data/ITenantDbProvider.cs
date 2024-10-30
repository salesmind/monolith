namespace SalesMind.Infrastructure.Data;
public interface ITenantDbProvider : IDisposable
{
    TenantDbContext GetOrCreate(Guid tenantId);
}
