using AsuraGate.Persistence.Dynamic.Entities;
using AsuraGate.Persistence.Mappers;

namespace AsuraGate.Persistence.Dynamic.Repositories;

/// <summary>
/// Generic append-only snapshot repository. Every dynamic entity is shaped identically
/// (an autoincrementing id, a timestamp, and a JSON <c>data</c> blob), so this one
/// implementation covers every model - concrete repositories just supply the JSON fallback
/// to use when serialization fails ("[]" for collection models, "null" for single-object ones).
/// </summary>
public abstract class SnapshotRepository<TModel, TEntity> :
    ISnapshotRepository<TModel>
    where TEntity : class, ISnapshotEntity, new()
{
    private readonly ISnapshotDatabase _database;
    private readonly string _emptyDefault;

    protected SnapshotRepository(ISnapshotDatabase database, string emptyDefault = "null")
    {
        _database = database;
        _emptyDefault = emptyDefault;
    }

    private TEntity ToEntity(TModel model, DateTime timestamp) => new TEntity
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? _emptyDefault
    };

    private static TModel? ToModel(TEntity entity) => MapperUtils.DeserializeJson<TModel>(entity.Data);

    /// <summary>Records a new snapshot, stamped with <paramref name="timestamp"/> or now if omitted.</summary>
    public Task InsertAsync(TModel model, DateTime? timestamp = null) =>
        _database.Connection.InsertAsync(ToEntity(model, timestamp ?? DateTime.UtcNow));

    /// <summary>Returns the most recently recorded snapshot; null if none have been recorded yet.</summary>
    public async Task<TModel?> GetLatestAsync()
    {
        TEntity? entity = await _database.Connection.Table<TEntity>()
            .OrderByDescending(entity => entity.Timestamp)
            .FirstOrDefaultAsync();
        return entity is null ? default : ToModel(entity);
    }

    /// <summary>Returns the first snapshot ever recorded; null if none have been recorded yet.</summary>
    public async Task<TModel?> GetOldestAsync()
    {
        TEntity? entity = await _database.Connection.Table<TEntity>()
            .OrderBy(entity => entity.Timestamp)
            .FirstOrDefaultAsync();
        return entity is null ? default : ToModel(entity);
    }

    /// <summary>Returns the snapshot that was current at <paramref name="timestamp"/> - the latest one recorded at or before it; null if none exist that far back.</summary>
    public async Task<TModel?> GetAsOfAsync(DateTime timestamp)
    {
        TEntity? entity = await _database.Connection.Table<TEntity>()
            .Where(entity => entity.Timestamp <= timestamp)
            .OrderByDescending(entity => entity.Timestamp)
            .FirstOrDefaultAsync();
        return entity is null ? default : ToModel(entity);
    }

    /// <summary>Returns the total number of snapshots recorded, without deserializing any of them.</summary>
    public Task<int> CountAsync() => _database.Connection.Table<TEntity>().CountAsync();

    /// <summary>Deletes every snapshot recorded before <paramref name="olderThan"/>; returns how many rows were removed.</summary>
    public Task<int> PruneAsync(DateTime olderThan) =>
        _database.Connection.Table<TEntity>().Where(entity => entity.Timestamp < olderThan).DeleteAsync();

    /// <summary>Returns every recorded snapshot, oldest first; use <paramref name="skip"/>/<paramref name="take"/> to page through a large history.</summary>
    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetAllAsync(int skip = 0, int? take = null) =>
        QueryAsync(since: null, until: null, skip, take);

    /// <summary>Returns every snapshot recorded at or after <paramref name="since"/> (or all of them if omitted), oldest first.</summary>
    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetHistoryAsync(DateTime? since = null, int skip = 0, int? take = null) =>
        QueryAsync(since, until: null, skip, take);

    /// <summary>Returns every snapshot recorded between <paramref name="start"/> and <paramref name="end"/> (inclusive), oldest first.</summary>
    public Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetRangeAsync(DateTime start, DateTime end, int skip = 0, int? take = null) =>
        QueryAsync(start, end, skip, take);

    private async Task<IEnumerable<(DateTime Timestamp, TModel Model)>> QueryAsync(DateTime? since, DateTime? until, int skip = 0, int? take = null)
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
            .Select(entity => (entity.Timestamp, Model: ToModel(entity)))
            .Where(entry => entry.Model is not null)
            .Select(entry => (entry.Timestamp, entry.Model!));
    }
}
