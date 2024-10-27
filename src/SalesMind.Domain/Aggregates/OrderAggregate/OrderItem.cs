namespace SalesMind.Domain.Aggregates.OrderAggregate;
public class OrderItem : Entity<long>
{
    public int ProductId { get; set; }
    public long ProductSkuId { get; set; }
    public string ProductName { get; set; }
    public string SkuAttributes { get; set; }
    public Guid? ProductFileId { get; set; }
    public decimal UnitPrice { get; private set; }
    public int Units { get; private set; }
    public decimal Discount { get; private set; }
}
