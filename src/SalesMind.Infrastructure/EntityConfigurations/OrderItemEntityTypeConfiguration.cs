using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesMind.Domain.Aggregates.OrderAggregate;

namespace SalesMind.Infrastructure.EntityConfigurations;
public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("order_items");
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property<long>("order_id");

        builder.Property(x => x.ProductName).HasColumnName("product_name").IsRequired(true);
        builder.Property(x => x.UnitPrice).HasColumnName("unit_price").HasColumnType("NUMERIC(10, 2)");
        builder.Property(x => x.Discount).HasColumnName("discount").HasColumnType("NUMERIC(10, 2)");
        builder.Property(x => x.Units).HasColumnName("units");

        builder.Property(x => x.ProductId).HasColumnName("product_id");
        builder.Property(x => x.ProductSkuId).HasColumnName("product_sku_id");
        builder.Property(x => x.SkuAttributes).HasColumnName("sku_attributes").HasColumnType("jsonb");
        builder.Property(x => x.ProductFileId).HasColumnName("product_file_id").HasColumnType("uuid");
    }
}