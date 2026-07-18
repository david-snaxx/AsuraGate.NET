using AsuraGate.Persistence.Dynamic.Repositories;

namespace AsuraGate.Persistence.Dynamic.Entities;

/// <summary>
/// Marks an autoincrementing, timestamped snapshot entity so <see cref="SnapshotRepository{TModel,TEntity}"/>
/// can query the latest/history rows generically, without knowing the concrete entity type.
/// </summary>
public interface ISnapshotEntity
{
    int Id { get; set; }
    DateTime Timestamp { get; set; }
    string Data { get; set; }
}
