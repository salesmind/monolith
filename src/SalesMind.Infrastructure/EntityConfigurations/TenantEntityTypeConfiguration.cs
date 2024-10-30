using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SalesMind.Domain.Aggregates.TenantAggregate;

namespace SalesMind.Infrastructure.EntityConfigurations;
internal class TenantEntityTypeConfiguration: IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("tenants");
        builder.Property(t => t.Id).HasColumnName("id").HasColumnType("uuid").HasValueGenerator(typeof(SequentialGuidValueGenerator));
        builder.Property(x => x.Name).HasColumnName("name").IsRequired(true);
        builder.Property(x => x.DisplayName).HasColumnName("display_name").IsRequired(true);
        builder.Property(x => x.Description).HasColumnName("description").IsRequired(false);
        builder.Property(x => x.SubDomain).HasColumnName("sub_domain").IsRequired(false);
        builder.Property(x => x.Status).HasColumnName("status").HasConversion<string>().IsRequired(true);
        builder.Property(x => x.Level).HasColumnName("level").HasConversion<string>().IsRequired(true);
        builder.Property(x => x.ExpiredAt).HasColumnName("expired_at").HasColumnType("timestamp with time zone");
        builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired(true);
        builder.Property(x => x.ModifiedBy).HasColumnName("modified_by");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone").ValueGeneratedOnAdd().HasDefaultValueSql("now()");
        builder.Property(x => x.ModifiedAt).HasColumnName("modified_at").HasColumnType("timestamp with time zone").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
    }
}
