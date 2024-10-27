namespace SalesMind.Domain.Aggregates.TenantAggregate;
public class Tenant : Entity<Guid>, IAggregateRoot
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string SubDomain { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public TenantStatus Status { get; set; }
    public TenantLevel Level { get; set; }
    public DateTime? ExpiredAt { get; set; }
}
