namespace AsuraGate.Persistence.Dynamic.Repositories;

public interface ISnapshotRepository<TModel>
{
    Task InsertAsync(TModel model, DateTime? timestamp = null);
    Task<TModel?> GetLatestAsync();
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetAllAsync();
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetHistoryAsync(DateTime? since = null);
    Task<IEnumerable<(DateTime Timestamp, TModel Model)>> GetRangeAsync(DateTime start, DateTime end);
}
