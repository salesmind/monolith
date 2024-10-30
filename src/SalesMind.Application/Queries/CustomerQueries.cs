using AutoMapper;
using SalesMind.Application.Constants;
using SalesMind.Application.Models.Customers;
using SalesMind.Infrastructure.Caching;
using SalesMind.Infrastructure.Data;

namespace SalesMind.Application.Queries;

public class CustomerQueries(IMapper mapper, ITenantDbProvider tenantDbProvider, ICacheManager cacheManager) : ICustomerQueries
{
    public async Task<CustomerDTO> GetById(Guid tenantId, int id)
    {
        return await cacheManager.GetOrCreateAsync(CacheKeys.GetCustomerById(tenantId, id), async () =>
        {
            var db = tenantDbProvider.GetOrCreate(tenantId);
            var customer = db.Customers.FindAsync(id);
            return mapper.Map<CustomerDTO>(customer);
        });
    }
}
