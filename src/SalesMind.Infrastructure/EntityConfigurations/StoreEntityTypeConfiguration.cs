using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesMind.Domain.Entities;
namespace SalesMind.Stores.Infrastructure;
internal class StoreEntityTypeConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("stores");
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").IsRequired(true);
        builder.Property(x => x.Code).HasColumnName("code").IsRequired(true);
        builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.Status).HasColumnName("status").HasConversion<string>().IsRequired(true);

        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone");
        builder.Property(x => x.ModifiedAt).HasColumnName("modified_at").HasColumnType("timestamp with time zone");
    }
}