using SQLite;
using AsuraGate.Persistence.Dynamic.Entities.V2.Account;

namespace AsuraGate.Persistence;

/// <summary>
/// Owns the single SQLite connection backing dynamic/account-scoped data, kept in its own
/// database file separate from <see cref="Gw2ApiPersistenceDatabase"/> — that one is a
/// disposable, fully regenerable cache of GW2's static reference data, while this one holds
/// account history that can't be re-fetched once time has passed, so the two shouldn't share
/// a file or a reset/backup story.
/// </summary>
public class Gw2ApiDynamicDatabase : IAsyncDisposable
{
    public SQLiteAsyncConnection Connection { get; }

    public Gw2ApiDynamicDatabase(string databasePath)
    {
        Connection = new SQLiteAsyncConnection(databasePath);
    }

    public async ValueTask DisposeAsync()
    {
        await Connection.CloseAsync();
    }

    public async Task Initialize()
    {
        // from /v2/account
        await Connection.CreateTableAsync<AccountDyeSnapshotEntity>();
    }
}
