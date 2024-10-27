using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMind.Domain.Aggregates.ProductAggregate;

namespace SalesMind.Infrastructure.EntityConfigurations;
public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").IsRequired(true);
        builder.Property(x => x.Code).HasColumnName("code").IsRequired(true);
        builder.Property(x => x.Description).HasColumnName("description").IsRequired(false);
        builder.Property(x => x.Status).HasColumnName("status").HasConversion<string>().IsRequired(true);
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone");
        builder.Property(x => x.ModifiedAt).HasColumnName("modified_at").IsRequired(false).HasColumnType("timestamp with time zone");

        builder.HasMany(s => s.ProductSkus).WithOne().HasForeignKey("product_id");
        builder.HasMany(s => s.ProductPictures).WithOne().HasForeignKey("product_id");
    }
}
