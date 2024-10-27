using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMind.Domain.Entities;

namespace SalesMind.Infrastructure.EntityConfigurations;
internal class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("warehouses");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").IsRequired(true);
        builder.Property(x => x.Code).HasColumnName("code").IsRequired(true);
        builder.Property(x => x.Location).HasColumnName("location").IsRequired(false);
        builder.Property(x => x.Description).HasColumnName("description").IsRequired(false);

        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone");
        builder.Property(x => x.ModifiedAt).HasColumnName("modified_at").HasColumnType("timestamp with time zone");
    }
}
