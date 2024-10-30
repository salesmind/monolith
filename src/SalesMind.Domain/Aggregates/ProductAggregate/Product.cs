namespace SalesMind.Domain.Aggregates.ProductAggregate;
public class Product : Entity<int>, IAggregateRoot
{
    private List<ProductSku> _productSkus = [];
    private List<ProductPicture> _productPictures = [];
    public string Name { get; set; }
    public string Code { get; set; }
    public string ExternalId { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public ProductStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public IReadOnlyCollection<ProductSku> ProductSkus => _productSkus;
    public IReadOnlyCollection<ProductPicture> ProductPictures => _productPictures;
}