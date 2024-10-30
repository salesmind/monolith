namespace SalesMind.Application.Constants;
public static class CacheKeys
{
    public static string GetAllTenants => "tenants";
    public static string GetCustomerById(Guid tenantId, int id) => $"customer_{tenantId}_{id}";
}
