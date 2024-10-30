
using Microsoft.EntityFrameworkCore;
using SalesMind.Infrastructure;

namespace SalesMind.API.Setup;

public class SharedDbSeeder(IServiceProvider serviceProvider) : IDbSeeder<SharedDbContext>
{
    public async Task SeedAsync(SharedDbContext context)
    {
        if (!await context.Tenants.AnyAsync())
        {
            await context.Tenants.AddAsync(new Domain.Aggregates.TenantAggregate.Tenant
            {
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "system",
                DisplayName = "SalesMind",
                ExpiredAt = DateTime.UtcNow.AddYears(1),
                Level = Domain.Aggregates.TenantAggregate.TenantLevel.Free,
                ModifiedAt = DateTime.UtcNow,
                Name = "salesmind",
                Status = Domain.Aggregates.TenantAggregate.TenantStatus.Available,
                SubDomain = "salesmind"
            });
            await context.Tenants.AddAsync(new Domain.Aggregates.TenantAggregate.Tenant
            {
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "system",
                DisplayName = "Deepin",
                ExpiredAt = DateTime.UtcNow.AddYears(1),
                Level = Domain.Aggregates.TenantAggregate.TenantLevel.Free,
                ModifiedAt = DateTime.UtcNow,
                Name = "deepin",
                Status = Domain.Aggregates.TenantAggregate.TenantStatus.Available,
                SubDomain = "deepin"
            });
            await context.SaveChangesAsync();
        }
    }
}
