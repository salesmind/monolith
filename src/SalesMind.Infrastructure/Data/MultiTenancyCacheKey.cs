using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SalesMind.Infrastructure.Data;

public class MultiTenancyCacheKey : ModelCacheKey
{
    private readonly string _schema;
    public MultiTenancyCacheKey(string schema, DbContext context) : base(context)
    {
        _schema = schema;
    }
    public override int GetHashCode()
    {
        var hashCode = base.GetHashCode() * 397;
        if (_schema != null)
        {
            hashCode ^= _schema.GetHashCode();
        }
        return hashCode;
    }
    protected override bool Equals(ModelCacheKey other)
    {
        return base.Equals(other) && (other as MultiTenancyCacheKey)?._schema == _schema;
    }
}
