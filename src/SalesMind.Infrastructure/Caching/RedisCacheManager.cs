using Newtonsoft.Json;
using StackExchange.Redis;
using System.Net;

namespace SalesMind.Infrastructure.Caching;
public class RedisCacheManager : ICacheManager
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;
    private readonly int _defaultCacheTimeMinutes;
    public RedisCacheManager(IConnectionMultiplexer redis, int defaultCacheTimeMinutes = 30)
    {
        _redis = redis;
        _database = _redis.GetDatabase();
        _defaultCacheTimeMinutes = defaultCacheTimeMinutes;
    }
    public async Task ClearAsync()
    {
        foreach (var endPoint in _redis.GetEndPoints())
        {
            var keys = this.GetKeys(endPoint);
            if (keys != null && keys.Any())
                await _database.KeyDeleteAsync(keys.ToArray());
        }
    }

    public async Task<T> GetAsync<T>(string key)
    {
        if (string.IsNullOrEmpty(key))
            return default;
        var serializedItem = await _database.StringGetAsync(key);
        if (!serializedItem.HasValue)
            return default;
        var item = JsonConvert.DeserializeObject<T>(serializedItem);
        return item;
    }

    public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> acquire)
    {
        return await this.GetOrCreateAsync(key, acquire, _defaultCacheTimeMinutes);
    }

    public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> acquire, int cacheTime)
    {
        T result = default;
        if (string.IsNullOrEmpty(key))
        {
            return result;
        }
        if (await IsSetAsync(key))
        {
            result = await this.GetAsync<T>(key);
        }
        if (result == null)
        {
            result = await acquire();
            if (result != null)
            {
                await this.SetAsync(key, result, cacheTime);
            }
        }
        return result;
    }

    public async Task<bool> IsSetAsync(string key)
    {
        return await _database.KeyExistsAsync(key);
    }

    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }

    public async Task RemoveByPrefix(string prefix)
    {
        foreach (var endPoint in _redis.GetEndPoints())
        {
            var keys = this.GetKeys(endPoint, prefix);
            if (keys != null && keys.Any())
                await _database.KeyDeleteAsync(keys.ToArray());
        }
    }

    public Task SetAsync<T>(string key, T data)
    {
        return this.SetAsync(key, data, _defaultCacheTimeMinutes);
    }

    public async Task SetAsync<T>(string key, T data, int cacheTimeMinutes)
    {
        if (string.IsNullOrEmpty(key))
            return;

        if (data == null)
            return;

        var serializedItem = JsonConvert.SerializeObject(data);
        await _database.StringSetAsync(key, serializedItem, expiry: cacheTimeMinutes > 0 ? TimeSpan.FromSeconds(cacheTimeMinutes) : null);
    }

    private IEnumerable<RedisKey> GetKeys(EndPoint endPoint, string prefix = null)
    {
        var server = _redis.GetServer(endPoint);
        var keys = server.Keys(_database.Database, string.IsNullOrEmpty(prefix) ? null : $"{prefix}*");
        return keys;
    }
}
