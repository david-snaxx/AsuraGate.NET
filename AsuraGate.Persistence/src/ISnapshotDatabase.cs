using SQLite;

namespace AsuraGate.Persistence;

/// <summary>
/// Contract for a database wrapper that owns a single SQLite connection backing append-only
/// snapshot tables, so <see cref="Dynamic.Repositories.SnapshotRepository{TModel,TEntity}"/> can
/// operate generically regardless of which kind of dynamic data the connection actually belongs
/// to, without depending on a single concrete database class.
/// </summary>
public interface ISnapshotDatabase
{
    SQLiteAsyncConnection Connection { get; }
}
