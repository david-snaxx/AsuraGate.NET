namespace AsuraGate.Persistence.Repositories;

public interface IStaticRepository<TModel, TId>
{
    Task<TModel?> GetAsync(TId id);
    Task<IEnumerable<TModel>> GetManyAsync(IEnumerable<TId> ids);
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<IEnumerable<TId>> GetCachedIdsAsync();
    Task UpsertAsync(TModel model);
    Task UpsertAllAsync(IEnumerable<TModel> models);
    Task DeleteAsync(TId id);
}
