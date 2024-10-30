namespace SalesMind.Application.Models.Tenancy;
public class TenantIdentity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TenantIdentity(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
