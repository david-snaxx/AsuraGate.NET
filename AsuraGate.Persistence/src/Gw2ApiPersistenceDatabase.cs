using SQLite;

namespace AsuraGate.Persistence;

/// <summary>
/// Owns the single SQLite connection backing the id-data cache. Repositories use
/// <see cref="Connection"/> directly rather than opening their own connections.
/// </summary>
public class Gw2ApiPersistenceDatabase : IAsyncDisposable
{
    public SQLiteAsyncConnection Connection { get; }

    public Gw2ApiPersistenceDatabase(string databasePath)
    {
        Connection = new SQLiteAsyncConnection(databasePath);
    }

    public async ValueTask DisposeAsync()
    {
        await Connection.CloseAsync();
    }
}
