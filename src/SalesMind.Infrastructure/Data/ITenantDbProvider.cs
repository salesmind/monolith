namespace SalesMind.Infrastructure.Data;
public interface ITenantDbProvider
{
    TenantDbContext GetOrCreate(Guid tenantId);
}
