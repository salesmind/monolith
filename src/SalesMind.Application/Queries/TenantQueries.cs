using Microsoft.EntityFrameworkCore;
using SalesMind.Application.Constants;
using SalesMind.Application.Models.Tenancy;
using SalesMind.Infrastructure;
using SalesMind.Infrastructure.Caching;
using SalesMind.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMind.Application.Queries;
public class TenantQueries(ICacheManager cacheManager, SharedDbContext sharedDbContext) : ITenantQueries
{
    public async Task<IEnumerable<TenantIdentity>> GetTenantsAsync()
    {
        return await cacheManager.GetOrCreateAsync(CacheKeys.GetAllTenants,
            () => sharedDbContext.Tenants.Select(s => new TenantIdentity(s.Id, s.Name)).ToListAsync());
    }
}
