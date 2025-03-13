using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace PostsCaching.Services.Caching
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache) => _cache = cache;

        public async Task<T?> GetDataAsync<T>(string key)
        {
            string? data = await _cache.GetStringAsync(key);

            if (data is null)
                return default;

            return JsonSerializer.Deserialize<T>(data);
        }

        public Task InvalidateAsync(string key) => _cache.RemoveAsync(key);

        public async Task SetDataAsync<T>(string key, T data, DistributedCacheEntryOptions? cacheOptions = null)
        {
            cacheOptions ??= new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(key, JsonSerializer.Serialize(data));
        }
    }
}
