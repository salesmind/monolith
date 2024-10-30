using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesMind.Domain.Aggregates.TenantAggregate;
using SalesMind.Infrastructure.EntityConfigurations;

namespace SalesMind.Infrastructure;
public class SharedDbContext : DbContextBase<SharedDbContext>
{
    public SharedDbContext(DbContextOptions<SharedDbContext> options, IMediator mediator = null) : base(options, mediator)
    {
    }
    public override string Schema => "public";
    public DbSet<Tenant> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new TenantEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FeatureEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FeatureTargetEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FileObjectEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
