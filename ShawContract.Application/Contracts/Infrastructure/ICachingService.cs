using System;
using System.Threading.Tasks;

namespace ShawContract.Application.Contracts.Infrastructure
{
    public interface ICachingService
    {
        T GetOrCreateItem<T>(string key, Func<T> CreateItem, int? timeout = null);

        Task<T> GetOrCreateItemAsync<T>(string key, Func<Task<T>> CreateItem, int? timeout = null);
    }
}
