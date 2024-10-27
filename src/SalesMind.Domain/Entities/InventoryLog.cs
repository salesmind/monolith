using SalesMind.Domain.Enumrations;

namespace SalesMind.Domain.Entities;
public class InventoryLog : Entity<long>
{
    public string Note { get; set; }
    public int Quantity { get; set; }
    public InventoryChangeType ChangeType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public Inventory Inventory { get; set; }
    public int InventoryId { get; set; }
}
