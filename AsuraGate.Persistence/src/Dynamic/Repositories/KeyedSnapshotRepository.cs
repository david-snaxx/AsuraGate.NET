using AsuraGate.Persistence.Dynamic.Entities;

namespace AsuraGate.Persistence.Dynamic.Repositories;

/// <summary>
/// Generic append-only snapshot repository for tables where a single database holds interleaved
/// history for more than one subject (e.g. every character on an account), keyed by a string
/// subject key. Mirrors <see cref="SnapshotRepository{TModel,TEntity}"/> exactly, with every
/// operation additionally filtered to one subject's timeline.
/// </summary>
public abstract class KeyedSnapshotRepository<TModel, TEntity> :
    IKeyedSnapshotRepository<TModel>
    where TEntity : class, IKeyedSnapshotEntity, new()
{
    private readonly ISnapshotDatabase _database;
    private readonly Func<string, TModel, DateTime, TEntity> _toEntity;
    private readonly Func<TEntity, TModel?> _toModel;

    protected KeyedSnapshotRepository(ISnapshotDatabase database, Func<string, TModel, DateTime, TEntity> toEntity, Func<TEntity, TModel?> toModel)
    {
        _database = database;
        _toEntity = toEntity;
        _toModel = toModel;
    }

    public Task InsertAsync(string key, TModel model, DateTime? timestamp = null) =>
        _database.Connection.InsertAsync(_toEntity(key, model, timestamp ?? DateTime.UtcNow));

    public async Task<TModel?> GetLatestAsync(string key)
    {
        TEntity? entity = await _database.Connection.Table<TEntity>()
            .Where(entity => entity.Key == key)
            .OrderByDescending(entity => entity.Timestamp)
            .FirstOrDefaultAsync();
        return entity is null ? default : _toModel(entity);
    }

    public async Task<TModel?> GetOldestAsync(string key)
    {
        TEntity? entity = await _database.Connection.Table<TEntity>()
            .Where(entity => entity.Key == key)
            .OrderBy(entity => entity.Timestamp)
            .FirstOrDefaultAsync();
        return entity is null ? default : _toModel(entity);
    }

    public async Task<TModel?> GetAsOfAsync(string key, DateTime timestamp)
    {
        TEntity? entity = await _database.Connection.Table<TEntity>()
            .Where(entity => entity.Key == key && entity.Timestamp <= timestamp)
            .OrderByDescending(entity => entity.Timestamp)
            .FirstOrDefaultAsync();
        return entity is null ? default : _toModel(entity);
    }

    public Task<int> CountAsync(string key) =>
        _database.Connection.Table<TEntity>().Where(entity => entity.Key == key).CountAsync();

    public Task<int> PruneAsync(string key, DateTime olderThan) =>
        _database.Connection.Table<TEntity>().Where(entity => entity.Key == key && entity.Timestamp < olderThan).DeleteAsync();

    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetAllAsync(string key, int skip = 0, int? take = null) =>
        QueryAsync(key, since: null, until: null, skip, take);

    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetHistoryAsync(string key, DateTime? since = null, int skip = 0, int? take = null) =>
        QueryAsync(key, since, until: null, skip, take);

    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetRangeAsync(string key, DateTime start, DateTime end, int skip = 0, int? take = null) =>
        QueryAsync(key, start, end, skip, take);

    private async Task<IEnumerable<(DateTime Timestamp, TModel Model)>> QueryAsync(string key, DateTime? since, DateTime? until, int skip, int? take)
    {
        var query = _database.Connection.Table<TEntity>().Where(entity => entity.Key == key);
        if (since is { } start)
        {
            query = query.Where(entity => entity.Timestamp >= start);
        }
        if (until is { } end)
        {
            query = query.Where(entity => entity.Timestamp <= end);
        }

        query = query.OrderBy(entity => entity.Timestamp);
        if (skip > 0)
        {
            query = query.Skip(skip);
        }
        if (take is { } limit)
        {
            query = query.Take(limit);
        }

        List<TEntity> entities = await query.ToListAsync();
        return entities
            .Select(entity => (entity.Timestamp, Model: _toModel(entity)))
            .Where(entry => entry.Model is not null)
            .Select(entry => (entry.Timestamp, entry.Model!));
    }
}
