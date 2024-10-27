using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesMind.Domain.Aggregates.ProductAggregate;

namespace SalesMind.Infrastructure.EntityConfigurations;

public class ProductSkuAttributeEntityTypeConfiguration : IEntityTypeConfiguration<ProductSkuAttribute>
{
    public void Configure(EntityTypeBuilder<ProductSkuAttribute> builder)
    {
        builder.ToTable("product_sku_attributes");
        builder.Property<long>("product_sku_id");
        builder.Property(s => s.Id).HasColumnName("id");

        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Value).HasColumnName("value");
    }
}
