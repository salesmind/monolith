namespace SalesMind.Domain.Entities;
public class Warehouse : Entity<int>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
