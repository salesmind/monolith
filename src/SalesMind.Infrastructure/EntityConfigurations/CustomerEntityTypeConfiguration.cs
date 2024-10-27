using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMind.Domain.Entities;

namespace SalesMind.Infrastructure.EntityConfigurations;
internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").IsRequired(true);
        builder.Property(x => x.Description).HasColumnName("description");

        builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired(true);
        builder.Property(x => x.ModifiedBy).HasColumnName("modified_by");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone");
        builder.Property(x => x.ModifiedAt).HasColumnName("modified_at").HasColumnType("timestamp with time zone");
    }
}
