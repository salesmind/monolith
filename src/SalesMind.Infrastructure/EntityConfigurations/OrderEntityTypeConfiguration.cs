using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SalesMind.Domain.Aggregates.OrderAggregate;

namespace SalesMind.Infrastructure.EntityConfigurations;
public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.Property(s => s.Id).HasColumnName("id").HasValueGenerator(typeof(SequentialGuidValueGenerator));
        builder.Property(x => x.OrderNo).HasColumnName("order_no").IsRequired(true);
        builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.Status).HasColumnName("status").HasConversion<string>();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone");
        builder.Property(x => x.ModifiedAt).HasColumnName("modified_at").IsRequired(false).HasColumnType("timestamp with time zone");

        builder.HasMany(s => s.Items).WithOne().HasForeignKey("order_id");
        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(x => x.Country).HasColumnName("country");
            address.Property(x => x.State).HasColumnName("state");
            address.Property(x => x.City).HasColumnName("city");
            address.Property(x => x.Street).HasColumnName("street");
            address.Property(x => x.ZipCode).HasColumnName("zip_code");
        });
    }
}
