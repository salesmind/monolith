namespace SalesMind.Domain.Aggregates.ProductAggregate;
public class ProductPicture : Entity<int>
{
    public Guid FileId { get; set; }
    public string Name { get; set; }
    public string Format { get; set; }
    public int DisplayOrder { get; set; }
}
