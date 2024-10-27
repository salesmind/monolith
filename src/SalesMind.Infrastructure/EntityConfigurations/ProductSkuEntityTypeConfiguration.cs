using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMind.Domain.Aggregates.ProductAggregate;

namespace SalesMind.Infrastructure.EntityConfigurations;
public class ProductSkuEntityTypeConfiguration : IEntityTypeConfiguration<ProductSku>
{
    public void Configure(EntityTypeBuilder<ProductSku> builder)
    {
        builder.ToTable("product_skus");
        builder.Property<int>("product_id");
        builder.Property(s => s.Id).HasColumnName("id");

        builder.Property(x => x.Code).HasColumnName("code");
        builder.Property(x => x.Cost).HasColumnName("cost").HasColumnType("DECIMAL(18,2)");
        builder.Property(x => x.Price).HasColumnName("price").HasColumnType("DECIMAL(18,2)");
        builder.Property(x => x.StockQuantity).HasColumnName("stock_quantity");

        builder.HasMany(s => s.ProductSkuAttributes).WithOne().HasForeignKey("product_sku_id");
    }
}
