using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SalesMind.Infrastructure.Data;

public class MultiTenancyCacheKeyFactory : IModelCacheKeyFactory
{
    private string _schema;
    public object Create(DbContext context, bool designTime)
    {
        var tenantDbContext = context as TenantDbContext;
        _schema = tenantDbContext.Schema;
        return new MultiTenancyCacheKey(_schema, tenantDbContext);
    }
}
