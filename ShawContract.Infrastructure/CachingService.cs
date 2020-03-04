using Microsoft.Extensions.Caching.Memory;
using ShawContract.Application.Constants;
using ShawContract.Application.Contracts.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ShawContract.Infrastructure
{
    public class CachingService : ICachingService
    {
        private ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();

        public CachingService()
        {
            Cache = new MemoryCache(new MemoryCacheOptions());
        }

        public static int DefaultTimeout
        {
            get
            {
                int timeout = 5;
                string strTimeout = CmsDataHelper.GetSetting(ConfigurationKeys.CachingTimeoutMinutes);
                int.TryParse(strTimeout, out timeout);
                return timeout;
            }
        }

        private MemoryCache Cache { get; set; }

        public T GetOrCreateItem<T>(string key, Func<T> CreateItem, int? timeout = null)
        {
            T cacheEntry;
            if (!Cache.TryGetValue(key, out cacheEntry))
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                 mylock.WaitAsync();

                try
                {
                    cacheEntry = CreateItem();

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetPriority(CacheItemPriority.High)
                        .SetAbsoluteExpiration(timeout == null ? TimeSpan.FromMinutes(DefaultTimeout) : TimeSpan.FromMinutes(timeout.Value));

                    Cache.Set<T>(key, cacheEntry, cacheEntryOptions);
                }
                finally
                {
                    mylock.Release();
                }
            }
            return cacheEntry;
        }

        public async Task<T> GetOrCreateItemAsync<T>(string key, Func<Task<T>> CreateItem, int? timeout = null)
        {
            T cacheEntry;
            if (!Cache.TryGetValue(key, out cacheEntry))
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await mylock.WaitAsync();

                try
                {
                    cacheEntry = await CreateItem();

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetPriority(CacheItemPriority.High)
                        .SetAbsoluteExpiration(timeout == null ? TimeSpan.FromMinutes(DefaultTimeout) : TimeSpan.FromMinutes(timeout.Value));

                    Cache.Set<T>(key, cacheEntry, cacheEntryOptions);
                }
                finally
                {
                    mylock.Release();
                }
            }
            return cacheEntry;
        }
    }
}
