using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Entities.Wvw.V2;
using SQLite;

namespace AsuraGate.Persistence;

/// <summary>
/// Owns the single SQLite connection backing dynamic/account-scoped data (including data for
/// every character on the account), kept in its own database file separate from
/// <see cref="Gw2ApiPersistenceDatabase"/> — that one is a disposable, fully regenerable cache of
/// GW2's static reference data, while this one holds account history that can't be re-fetched
/// once time has passed, so the two shouldn't share a file or a reset/backup story.
/// </summary>
public class Gw2ApiDynamicDatabase : ISnapshotDatabase, IAsyncDisposable
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
        // WAL lets writers and readers proceed concurrently instead of the default rollback
        // journal's exclusive-lock-per-write, which matters once a high-frequency poller
        // (e.g. WvW) is inserting snapshots on the same connection as ordinary reads.
        await Connection.ExecuteScalarAsync<string>("PRAGMA journal_mode=WAL;");

        // from /v2/account
        await Connection.CreateTableAsync<AccountDyeSnapshotEntity>();
        await Connection.CreateTableAsync<AccountAchievementSnapshotEntity>();
        await Connection.CreateTableAsync<AccountBankSnapshotEntity>();
        await Connection.CreateTableAsync<AccountBuildStorageSnapshotEntity>();
        await Connection.CreateTableAsync<AccountEmoteSnapshotEntity>();
        await Connection.CreateTableAsync<AccountFinisherSnapshotEntity>();
        await Connection.CreateTableAsync<AccountGliderSnapshotEntity>();
        await Connection.CreateTableAsync<AccountHomeCatSnapshotEntity>();
        await Connection.CreateTableAsync<AccountHomeNodeSnapshotEntity>();
        await Connection.CreateTableAsync<AccountHomesteadDecorationSnapshotEntity>();
        await Connection.CreateTableAsync<AccountHomesteadGlyphSnapshotEntity>();
        await Connection.CreateTableAsync<AccountInventorySnapshotEntity>();
        await Connection.CreateTableAsync<AccountJadeBotSnapshotEntity>();
        await Connection.CreateTableAsync<AccountLegendaryArmorySnapshotEntity>();
        await Connection.CreateTableAsync<AccountLuckSnapshotEntity>();
        await Connection.CreateTableAsync<AccountMailCarrierSnapshotEntity>();
        await Connection.CreateTableAsync<AccountMasterySnapshotEntity>();
        await Connection.CreateTableAsync<AccountMasteryPointsSnapshotEntity>();
        await Connection.CreateTableAsync<AccountMaterialSnapshotEntity>();
        await Connection.CreateTableAsync<AccountMiniSnapshotEntity>();
        await Connection.CreateTableAsync<AccountMountSkinSnapshotEntity>();
        await Connection.CreateTableAsync<AccountMountTypeSnapshotEntity>();
        await Connection.CreateTableAsync<AccountNoveltySnapshotEntity>();
        await Connection.CreateTableAsync<AccountOutfitSnapshotEntity>();
        await Connection.CreateTableAsync<AccountProgressionSnapshotEntity>();
        await Connection.CreateTableAsync<AccountPvpHeroSnapshotEntity>();
        await Connection.CreateTableAsync<AccountRecipeSnapshotEntity>();
        await Connection.CreateTableAsync<AccountSkiffSnapshotEntity>();
        await Connection.CreateTableAsync<AccountSkinSnapshotEntity>();
        await Connection.CreateTableAsync<AccountTitleSnapshotEntity>();
        await Connection.CreateTableAsync<AccountWalletSnapshotEntity>();
        await Connection.CreateTableAsync<AccountWvwSnapshotEntity>();
        await Connection.CreateTableAsync<AccountWizardsVaultDailySnapshotEntity>();
        await Connection.CreateTableAsync<AccountWizardsVaultWeeklySnapshotEntity>();
        await Connection.CreateTableAsync<AccountWizardsVaultSpecialSnapshotEntity>();

        // from /v2/characters/:id
        await Connection.CreateTableAsync<CharacterBackstorySnapshotEntity>();
        await Connection.CreateTableAsync<CharacterBuildTabSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterCoreSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterCraftingSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterEquipmentSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterEquipmentTabSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterHeroPointSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterInventorySnapshotEntity>();
        await Connection.CreateTableAsync<CharacterQuestSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterRecipeSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterSabSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterSkillsSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterSpecializationsSnapshotEntity>();
        await Connection.CreateTableAsync<CharacterTrainingSnapshotEntity>();

        // from /v2/wvw/matches, keyed by match id - polled far more frequently than account/character data
        await Connection.CreateTableAsync<WvwMatchSnapshotEntity>();
        await Connection.CreateTableAsync<WvwMatchWorldOverviewSnapshotEntity>();
        await Connection.CreateTableAsync<WvwMatchWorldScoresSnapshotEntity>();
        await Connection.CreateTableAsync<WvwMatchWorldStatsSnapshotEntity>();
    }
}
