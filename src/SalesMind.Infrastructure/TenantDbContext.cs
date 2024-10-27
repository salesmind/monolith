using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SalesMind.Infrastructure.EntityConfigurations;
using SalesMind.Stores.Infrastructure;

namespace SalesMind.Infrastructure;
public class TenantDbContext : DbContextBase<TenantDbContext>
{
    private readonly string _tenantId;
    public TenantDbContext(DbContextOptions<TenantDbContext> options, string tenantId = "dev", IMediator mediator = null) : base(options, mediator)
    {
        _tenantId = tenantId;
    }

    public override string Schema => _tenantId;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new StoreEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new WarehouseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryLogEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSkuEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSkuAttributeEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Strong@Passw0rd;Database=salesmind");
        return new TenantDbContext(optionsBuilder.Options, "dev");
    }
}
