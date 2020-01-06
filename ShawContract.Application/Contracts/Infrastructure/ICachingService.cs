namespace ShawContract.Application.Contracts.Infrastructure
{
    public interface ICachingService
    {
        T GetItem<T>(string key);

        void SetItem<T>(string key, T item, int? timeout);
    }
}