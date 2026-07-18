namespace AsuraGate.Persistence.Dynamic.Repositories;

public interface IKeyedSnapshotRepository<TModel>
{
    /// <summary>Records a new snapshot for <paramref name="key"/>, stamped with <paramref name="timestamp"/> or now if omitted.</summary>
    Task InsertAsync(string key, TModel model, DateTime? timestamp = null);

    /// <summary>Returns the most recently recorded snapshot for <paramref name="key"/>; null if none have been recorded yet.</summary>
    Task<TModel?> GetLatestAsync(string key);

    /// <summary>Returns the first snapshot ever recorded for <paramref name="key"/>; null if none have been recorded yet.</summary>
    Task<TModel?> GetOldestAsync(string key);

    /// <summary>Returns the snapshot for <paramref name="key"/> that was current at <paramref name="timestamp"/> - the latest one recorded at or before it; null if none exist that far back.</summary>
    Task<TModel?> GetAsOfAsync(string key, DateTime timestamp);

    /// <summary>Returns the total number of snapshots recorded for <paramref name="key"/>, without deserializing any of them.</summary>
    Task<int> CountAsync(string key);

    /// <summary>Deletes every snapshot for <paramref name="key"/> recorded before <paramref name="olderThan"/>; returns how many rows were removed.</summary>
    Task<int> PruneAsync(string key, DateTime olderThan);

    /// <summary>Returns every recorded snapshot for <paramref name="key"/>, oldest first; use <paramref name="skip"/>/<paramref name="take"/> to page through a large history.</summary>
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetAllAsync(string key, int skip = 0, int? take = null);

    /// <summary>Returns every snapshot for <paramref name="key"/> recorded at or after <paramref name="since"/> (or all of them if omitted), oldest first.</summary>
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetHistoryAsync(string key, DateTime? since = null, int skip = 0, int? take = null);

    /// <summary>Returns every snapshot for <paramref name="key"/> recorded between <paramref name="start"/> and <paramref name="end"/> (inclusive), oldest first.</summary>
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetRangeAsync(string key, DateTime start, DateTime end, int skip = 0, int? take = null);
}
