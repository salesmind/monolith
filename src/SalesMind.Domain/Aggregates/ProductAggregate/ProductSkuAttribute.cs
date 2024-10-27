namespace SalesMind.Domain.Aggregates.ProductAggregate;
public class ProductSkuAttribute : Entity<long>
{
    public string Name { get; set; }
    public string Value { get; set; }
}
