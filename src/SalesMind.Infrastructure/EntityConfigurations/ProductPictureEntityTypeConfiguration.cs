using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesMind.Domain.Aggregates.ProductAggregate;

namespace SalesMind.Infrastructure.EntityConfigurations;

public class ProductPictureEntityTypeConfiguration : IEntityTypeConfiguration<ProductPicture>
{
    public void Configure(EntityTypeBuilder<ProductPicture> builder)
    {
        builder.ToTable("product_pictures");
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property<int>("product_id");

        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.FileId).HasColumnName("file_id").HasColumnType("uuid");
        builder.Property(x => x.Format).HasColumnName("format");
        builder.Property(x => x.DisplayOrder).HasColumnName("display_order");
    }
}
