namespace SalesMind.Infrastructure.Configurations;
public class AppSettings
{
    public string RedisConnection { get; set; }
    public string SharedDbConnection { get; set; }
    public string TenantDbConnection { get; set; }
}
