using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SalesMind.Domain.Entities;
using SalesMind.Infrastructure.Data;
using SalesMind.Infrastructure.EntityConfigurations;
using SalesMind.Stores.Infrastructure;

namespace SalesMind.Infrastructure;
public class TenantDbContext : DbContextBase<TenantDbContext>
{
    public const string DESIGN_TIME_TENANT = "dev";
    private readonly string _tenantId;
    public TenantDbContext(DbContextOptions<TenantDbContext> options, string tenantId, IMediator mediator = null) : base(options, mediator)
    {
        _tenantId = tenantId;
    }

    public override string Schema => _tenantId;
    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!IsDesignTimeTenant)
        {
            modelBuilder.HasDefaultSchema(Schema);
        }
        modelBuilder.ApplyConfiguration(new StoreEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new WarehouseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryLogEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSkuEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSkuAttributeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductPictureEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!IsDesignTimeTenant)
        {
            var options = RelationalOptionsExtension.Extract(optionsBuilder.Options)
                .WithMigrationsHistoryTableSchema(Schema);
            IDbContextOptionsBuilderInfrastructure builder = optionsBuilder;
            builder.AddOrUpdateExtension(options);
            optionsBuilder.ReplaceService<IModelCacheKeyFactory, MultiTenancyCacheKeyFactory>();
            optionsBuilder.ReplaceService<IMigrator, MultiTenancyMigrator>();
        }
        base.OnConfiguring(optionsBuilder);
    }
    private bool IsDesignTimeTenant => string.IsNullOrEmpty(_tenantId) ? throw new ArgumentNullException("Tenant Id must be not empty.") : _tenantId == DESIGN_TIME_TENANT;
}
public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql("Database=salesmind");
        return new TenantDbContext(optionsBuilder.Options, TenantDbContext.DESIGN_TIME_TENANT);
    }
}
