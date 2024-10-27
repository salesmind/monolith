namespace SalesMind.Domain.Aggregates.ProductAggregate;
public class ProductSku : Entity<long>
{
    private List<ProductSkuAttribute> _productSkuAttributes = [];
    public string Code {  get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public IReadOnlyCollection<ProductSkuAttribute> ProductSkuAttributes => _productSkuAttributes.AsReadOnly();
}
