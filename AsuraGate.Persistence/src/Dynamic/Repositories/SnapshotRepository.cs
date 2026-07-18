using AsuraGate.Persistence.Dynamic.Entities;

namespace AsuraGate.Persistence.Dynamic.Repositories;

/// <summary>
/// Generic append-only snapshot repository. Every dynamic entity is shaped identically
/// (an autoincrementing id, a timestamp, and a JSON <c>data</c> blob), so this one
/// implementation covers every model - concrete repositories just supply the model/entity
/// types and mapper delegates.
/// </summary>
public abstract class SnapshotRepository<TModel, TEntity> :
    ISnapshotRepository<TModel>
    where TEntity : class, ISnapshotEntity, new()
{
    private readonly Gw2ApiDynamicDatabase _database;
    private readonly Func<TModel, DateTime, TEntity> _toEntity;
    private readonly Func<TEntity, TModel?> _toModel;

    protected SnapshotRepository(Gw2ApiDynamicDatabase database, Func<TModel, DateTime, TEntity> toEntity, Func<TEntity, TModel?> toModel)
    {
        _database = database;
        _toEntity = toEntity;
        _toModel = toModel;
    }

    public Task InsertAsync(TModel model, DateTime? timestamp = null) =>
        _database.Connection.InsertAsync(_toEntity(model, timestamp ?? DateTime.UtcNow));

    public async Task<TModel?> GetLatestAsync()
    {
        TEntity? entity = await _database.Connection.Table<TEntity>()
            .OrderByDescending(entity => entity.Timestamp)
            .FirstOrDefaultAsync();
        return entity is null ? default : _toModel(entity);
    }

    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetAllAsync() =>
        QueryAsync(since: null, until: null);

    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetHistoryAsync(DateTime? since = null) =>
        QueryAsync(since, until: null);

    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetRangeAsync(DateTime start, DateTime end) =>
        QueryAsync(start, end);

    private async Task<IEnumerable<(DateTime Timestamp, TModel Model)>> QueryAsync(DateTime? since, DateTime? until)
    {
        var query = _database.Connection.Table<TEntity>();
        if (since is { } start)
        {
            query = query.Where(entity => entity.Timestamp >= start);
        }
        if (until is { } end)
        {
            query = query.Where(entity => entity.Timestamp <= end);
        }

        List<TEntity> entities = await query.OrderBy(entity => entity.Timestamp).ToListAsync();
        return entities
            .Select(entity => (entity.Timestamp, Model: _toModel(entity)))
            .Where(entry => entry.Model is not null)
            .Select(entry => (entry.Timestamp, entry.Model!));
    }
}
