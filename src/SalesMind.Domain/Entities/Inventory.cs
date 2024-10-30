namespace SalesMind.Domain.Entities;
public class Inventory : Entity<int>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public int WarehouseId { get; set; }
}
