
namespace EletronicSystem.Data.Repository.Interfaces
{
    public interface ICacheRepository
    {
        Task<T?> GetCacheValueAsync<T>(string key);
        Task SetCacheValueAsync<T>(string key, T value);
    }
}
