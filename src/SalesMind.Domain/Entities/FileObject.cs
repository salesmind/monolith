namespace SalesMind.Domain.Entities;
public class FileObject : Entity<Guid>
{
    public string Path { get; set; }
    public string Name { get; set; }
    public string Format { get; set; }
    public long ContentLength { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
