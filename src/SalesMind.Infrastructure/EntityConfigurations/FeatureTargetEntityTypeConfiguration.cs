using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMind.Domain.Entities;

namespace SalesMind.Infrastructure.EntityConfigurations;
public class FeatureTargetEntityTypeConfiguration : IEntityTypeConfiguration<FeatureTarget>
{
    public void Configure(EntityTypeBuilder<FeatureTarget> builder)
    {
        builder.ToTable("feature_targets");
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(t => t.TenantId).HasColumnName("tenant_id").HasColumnType("uuid");
        builder.Property(t => t.FeatureId).HasColumnName("feature_id");

        builder.HasOne(t => t.Feature).WithMany().HasForeignKey(x => x.FeatureId);
        builder.HasOne(t => t.Tenant).WithMany().HasForeignKey(x => x.TenantId);
    }
}
