namespace SalesMind.Domain.Aggregates.TenantAggregate;
public enum TenantStatus
{
    Created = 0,
    Available = 1,
    Paused = 2,
    Disabled = 3,
    Expired = 4,
}