using ShawContract.Application.Contracts.Infrastructure;

namespace ShawContract.Infrastructure
{
    public class CachingService : ICachingService
    {
        public CachingService()
        {
        }

        public T GetItem<T>(string key)
        {
            //TODO: update with specific caching implementation
            return default(T);
        }

        public void SetItem<T>(string key, T item, int? timeout)
        {
            //TODO: update with specific caching implementation
            return;
        }
    }
}