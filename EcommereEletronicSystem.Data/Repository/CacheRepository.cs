using EletronicSystem.Data.Repository.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace EletronicSystem.Data.Repository;
public class CacheRepository(IMemoryCache cache) : ICacheRepository
{
    private readonly MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(2));
   
    public async Task<T?> GetCacheValueAsync<T>(string key)
    {
        if (cache.TryGetValue(key, out T? cachedValue))
        {
            return await Task.FromResult(cachedValue);
        }

        return cachedValue;
    }

    public async Task SetCacheValueAsync<T>(string key, T value)
    {
        cache.Set(key, value, cacheOptions);

        await Task.CompletedTask;
    }
}

