namespace AsuraGate.StaticCache.Repositories;

public interface IStaticCacheRepository<TModel, TId>
{
    Task<TModel?> GetAsync(TId id);
    Task<IEnumerable<TModel>> GetAllAsync();
    Task UpsertAsync(TModel model);
    Task UpsertAllAsync(IEnumerable<TModel> models);
    Task DeleteAsync(TId id);
}