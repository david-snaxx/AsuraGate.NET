namespace AsuraGate.Persistence.Dynamic.Repositories;

public interface ISnapshotRepository<TModel>
{
    /// <summary>Records a new snapshot, stamped with <paramref name="timestamp"/> or now if omitted.</summary>
    Task InsertAsync(TModel model, DateTime? timestamp = null);

    /// <summary>Returns the most recently recorded snapshot; null if none have been recorded yet.</summary>
    Task<TModel?> GetLatestAsync();

    /// <summary>Returns the first snapshot ever recorded; null if none have been recorded yet.</summary>
    Task<TModel?> GetOldestAsync();

    /// <summary>Returns the snapshot that was current at <paramref name="timestamp"/> - the latest one recorded at or before it; null if none exist that far back.</summary>
    Task<TModel?> GetAsOfAsync(DateTime timestamp);

    /// <summary>Returns the total number of snapshots recorded, without deserializing any of them.</summary>
    Task<int> CountAsync();

    /// <summary>Deletes every snapshot recorded before <paramref name="olderThan"/>; returns how many rows were removed.</summary>
    Task<int> PruneAsync(DateTime olderThan);

    /// <summary>Returns every recorded snapshot, oldest first; use <paramref name="skip"/>/<paramref name="take"/> to page through a large history.</summary>
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetAllAsync(int skip = 0, int? take = null);

    /// <summary>Returns every snapshot recorded at or after <paramref name="since"/> (or all of them if omitted), oldest first.</summary>
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetHistoryAsync(DateTime? since = null, int skip = 0, int? take = null);

    /// <summary>Returns every snapshot recorded between <paramref name="start"/> and <paramref name="end"/> (inclusive), oldest first.</summary>
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetRangeAsync(DateTime start, DateTime end, int skip = 0, int? take = null);
}
