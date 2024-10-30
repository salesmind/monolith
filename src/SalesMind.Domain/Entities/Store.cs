using SalesMind.Domain.Enumrations;

namespace SalesMind.Domain.Entities;
public class Store : Entity<int>
{
    public required string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public StoreStatus Status { get; set; }
}