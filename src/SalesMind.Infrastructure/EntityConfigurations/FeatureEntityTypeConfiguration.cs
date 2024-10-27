using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMind.Domain.Entities;

namespace SalesMind.Infrastructure.EntityConfigurations;
public class FeatureEntityTypeConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.ToTable("features");
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").IsRequired(true);
        builder.Property(x => x.DisplayName).HasColumnName("display_name").IsRequired(true);
        builder.Property(x => x.Key).HasColumnName("key").IsRequired(true);
        builder.Property(x => x.Description).HasColumnName("description");

        builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired(true);
        builder.Property(x => x.ModifiedBy).HasColumnName("modified_by");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone");
        builder.Property(x => x.ModifiedAt).HasColumnName("modified_at").HasColumnType("timestamp with time zone");
    }
}
