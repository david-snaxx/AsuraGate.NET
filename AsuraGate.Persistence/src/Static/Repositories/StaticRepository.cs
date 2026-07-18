using AsuraGate.Persistence.Static.Entities;
using AsuraGate.Persistence.Mappers;

namespace AsuraGate.Persistence.Static.Repositories;

/// <summary>
/// Generic id+data cache repository. Every static entity is shaped identically
/// (an id column and a JSON <c>data</c> blob), so this one implementation covers
/// every model - concrete repositories just supply the model's id selector.
/// </summary>
public abstract class StaticRepository<TModel, TEntity, TId> :
    IStaticRepository<TModel, TId>
    where TEntity : class, IIdDataEntity<TId>, new()
{
    private readonly Gw2ApiPersistenceDatabase _database;
    private readonly Func<TModel, TId> _idSelector;

    protected StaticRepository(Gw2ApiPersistenceDatabase database, Func<TModel, TId> idSelector)
    {
        _database = database;
        _idSelector = idSelector;
    }

    protected virtual TEntity ToEntity(TModel model) => new TEntity
    {
        Id = _idSelector(model),
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    protected virtual TModel? ToModel(TEntity entity) => MapperUtils.DeserializeJson<TModel>(entity.Data);

    public async Task<TModel?> GetAsync(TId id)
    {
        var entity = await _database.Connection.FindAsync<TEntity>(id);
        return entity is null ? default : ToModel(entity);
    }

    public async Task<IEnumerable<TModel>> GetManyAsync(IEnumerable<TId> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<TEntity>()
            .Where(entity => idList.Contains(entity.Id))
            .ToListAsync();
        return entities.Select(ToModel).OfType<TModel>();
    }

    public async Task<IEnumerable<TModel>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<TEntity>().ToListAsync();
        return entities.Select(ToModel).OfType<TModel>();
    }

    public async Task<IEnumerable<TId>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<TEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(TModel model) => UpsertAllAsync([model]);

    public Task UpsertAllAsync(IEnumerable<TModel> models) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var model in models)
        {
            connection.InsertOrReplace(ToEntity(model));
        }
    });

    public Task DeleteAsync(TId id) => _database.Connection.DeleteAsync<TEntity>(id);
}
