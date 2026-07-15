using SQLite;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Entities.V2.Guild;
using AsuraGate.Persistence.Entities.V2.Pvp;
using AsuraGate.Persistence.Entities.V2.Wvw;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2.Achievements;
using AsuraGate.Persistence.Static.Entities.V2.Backstory;
using AsuraGate.Persistence.Static.Entities.V2.Guild;
using AsuraGate.Persistence.Static.Entities.V2.Homestead;
using AsuraGate.Persistence.Static.Entities.V2.Mount;
using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Persistence.Static.Entities.V2.Wvw;

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

    public async Task Initialize()
    {
        // from root /v2/
        await Connection.CreateTableAsync<ApiFileEntity>();
        await Connection.CreateTableAsync<ContinentEntity>();
        await Connection.CreateTableAsync<ContinentFloorEntity>();
        await Connection.CreateTableAsync<CurrencyEntity>();
        await Connection.CreateTableAsync<DungeonEntity>();
        await Connection.CreateTableAsync<DyeEntity>();
        await Connection.CreateTableAsync<EmblemComponentEntity>();
        await Connection.CreateTableAsync<EmoteEntity>();
        await Connection.CreateTableAsync<FinisherEntity>();
        await Connection.CreateTableAsync<GameMapEntity>();
        await Connection.CreateTableAsync<GliderEntity>();
        await Connection.CreateTableAsync<HomeCatEntity>();
        await Connection.CreateTableAsync<ItemEntity>();
        await Connection.CreateTableAsync<ItemStatEntity>();
        await Connection.CreateTableAsync<JadeBotEntity>();
        await Connection.CreateTableAsync<LegendaryArmoryItemEntity>();
        await Connection.CreateTableAsync<LegendEntity>();
        await Connection.CreateTableAsync<LogoEntity>();
        await Connection.CreateTableAsync<MailCarrierEntity>();
        await Connection.CreateTableAsync<MasteryEntity>();
        await Connection.CreateTableAsync<MaterialCategoryEntity>();
        await Connection.CreateTableAsync<MiniEntity>();
        await Connection.CreateTableAsync<NoveltyEntity>();
        await Connection.CreateTableAsync<OutfitEntity>();
        await Connection.CreateTableAsync<PetEntity>();
        await Connection.CreateTableAsync<ProfessionEntity>();
        await Connection.CreateTableAsync<QuagganEntity>();
        await Connection.CreateTableAsync<RaceEntity>();
        await Connection.CreateTableAsync<RaidEntity>();
        await Connection.CreateTableAsync<RecipeEntity>();
        await Connection.CreateTableAsync<SkiffEntity>();
        await Connection.CreateTableAsync<SkillEntity>();
        await Connection.CreateTableAsync<SkinEntity>();
        await Connection.CreateTableAsync<SpecializationEntity>();
        await Connection.CreateTableAsync<StoryEntity>();
        await Connection.CreateTableAsync<StoryJournalEntryEntity>();
        await Connection.CreateTableAsync<StorySeasonEntity>();
        await Connection.CreateTableAsync<TitleEntity>();
        await Connection.CreateTableAsync<TraitEntity>();
        await Connection.CreateTableAsync<WorldEntity>();

        // from /v2/achievements
        await Connection.CreateTableAsync<AchievementCategoryEntity>();
        await Connection.CreateTableAsync<AchievementEntity>();
        await Connection.CreateTableAsync<AchievementGroupEntity>();

        // from /v2/backstory
        await Connection.CreateTableAsync<BackstoryAnswerEntity>();
        await Connection.CreateTableAsync<BackstoryQuestionEntity>();

        // from /v2/guild
        await Connection.CreateTableAsync<GuildPermissionEntity>();
        await Connection.CreateTableAsync<GuildUpgradeEntity>();

        // from /v2/homestead
        await Connection.CreateTableAsync<HomesteadDecorationCategoryEntity>();
        await Connection.CreateTableAsync<HomesteadDecorationEntity>();
        await Connection.CreateTableAsync<HomesteadGlyphEntity>();

        // from /v2/mount
        await Connection.CreateTableAsync<MountSkinEntity>();
        await Connection.CreateTableAsync<MountTypeEntity>();

        // from /v2/pvp
        await Connection.CreateTableAsync<PvpAmuletEntity>();
        await Connection.CreateTableAsync<PvpHeroEntity>();
        await Connection.CreateTableAsync<PvpRankEntity>();

        // from /v2/wvw
        await Connection.CreateTableAsync<WvwAbilityEntity>();
        await Connection.CreateTableAsync<WvwObjectiveEntity>();
        await Connection.CreateTableAsync<WvwRankEntity>();
        await Connection.CreateTableAsync<WvwUpgradeEntity>();
    }
}
