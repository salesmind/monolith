# SalesMind.Monolith
dotnet ef migrations add InitialCreate -c SharedDbContext -p ../SalesMind.Infrastructure -o Migrations/Shared
dotnet ef migrations add InitialCreate -c TenantDbContext -p ../SalesMind.Infrastructure -o Migrations/Tenant