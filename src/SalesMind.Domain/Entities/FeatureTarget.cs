using SalesMind.Domain.Aggregates.TenantAggregate;

namespace SalesMind.Domain.Entities;
public class FeatureTarget : Entity<int>
{
    public Feature Feature { get; set; }
    public Tenant Tenant { get; set; }
    public int FeatureId { get; set; }
    public Guid TenantId { get; set; }
    public bool Value { get; set; }
}