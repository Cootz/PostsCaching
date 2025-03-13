using Microsoft.Extensions.Caching.Distributed;

namespace PostsCaching.Services.Caching
{
    public interface IRedisCacheService
    {
        /// <summary>
        /// Retreives data from Redis cache
        /// </summary>
        Task<T?> GetDataAsync<T>(string recentPostsCacheKey);

        /// <summary>
        /// Invalidates cache by deletining it from Redis
        /// </summary>
        Task InvalidateAsync(string recentPostsCacheKey);
        
        /// <summary>
        /// Add cache to Redis
        /// </summary>
        Task SetDataAsync<T>(string recentPostsCacheKey, T posts, DistributedCacheEntryOptions? cacheOptions = null);
    }
}