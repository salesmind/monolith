using SalesMind.Application.Models.Tenancy;

namespace SalesMind.Application.Queries;
public interface ITenantQueries
{
    Task<IEnumerable<TenantIdentity>> GetTenantsAsync();
}