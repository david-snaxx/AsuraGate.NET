using AsuraGate.Persistence.Entities;

namespace AsuraGate.Persistence.Repositories;

/// <summary>
/// Generic id+data cache repository. Every static entity is shaped identically
/// (an id column and a JSON <c>data</c> blob), so this one implementation covers
/// every model - concrete repositories just supply the model/entity types and mapper delegates.
/// </summary>
public abstract class StaticRepository<TModel, TEntity, TId> : 
    IStaticRepository<TModel, TId>
    where TEntity : class, IIdDataEntity<TId>, new()
{
    private readonly Gw2ApiPersistenceDatabase _database;
    private readonly Func<TModel, TEntity> _toEntity;
    private readonly Func<TEntity, TModel> _toModel;

    protected StaticRepository(Gw2ApiPersistenceDatabase database, Func<TModel, TEntity> toEntity, Func<TEntity, TModel> toModel)
    {
        _database = database;
        _toEntity = toEntity;
        _toModel = toModel;
    }

    public async Task<TModel?> GetAsync(TId id)
    {
        var entity = await _database.Connection.FindAsync<TEntity>(id);
        return entity is null ? default : _toModel(entity);
    }

    public async Task<IEnumerable<TModel>> GetManyAsync(IEnumerable<TId> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<TEntity>()
            .Where(entity => idList.Contains(entity.Id))
            .ToListAsync();
        return entities.Select(_toModel);
    }

    public async Task<IEnumerable<TModel>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<TEntity>().ToListAsync();
        return entities.Select(_toModel);
    }

    public async Task<IEnumerable<TId>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<TEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(TModel model) => UpsertAllAsync([model]);

    public Task UpsertAllAsync(IEnumerable<TModel> models) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var model in models)
        {
            connection.InsertOrReplace(_toEntity(model));
        }
    });

    public Task DeleteAsync(TId id) => _database.Connection.DeleteAsync<TEntity>(id);
}
