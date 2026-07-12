using SQLite;
using AsuraGate.StaticCache.Entities;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Entities.V2.Achievements;
using AsuraGate.StaticCache.Entities.V2.Backstory;
using AsuraGate.StaticCache.Entities.V2.Guild;
using AsuraGate.StaticCache.Entities.V2.Homestead;
using AsuraGate.StaticCache.Entities.V2.Mount;
using AsuraGate.StaticCache.Entities.V2.Pvp;
using AsuraGate.StaticCache.Entities.V2.Wvw;

namespace AsuraGate.StaticCache;

/// <summary>
/// Owns the single SQLite connection backing the static API data cache. Repositories use
/// <see cref="Connection"/> directly rather than opening their own connections.
/// </summary>
public class Gw2ApiStaticCacheDatabase : IAsyncDisposable
{
    public SQLiteAsyncConnection Connection { get; }

    public Gw2ApiStaticCacheDatabase(string databasePath)
    {
        Connection = new SQLiteAsyncConnection(databasePath);
    }
    
    public async ValueTask DisposeAsync()
    {
        await Connection.CloseAsync();
    }

    public async Task Initialize()
    {
        await Connection.CreateTableAsync<CacheMetaEntity>();

        // from root /v2/
        await Connection.CreateTableAsync<ApiFileEntity>();
        await Connection.CreateTableAsync<BuildEntity>();
        await Connection.CreateTableAsync<ContinentEntity>();
        await Connection.CreateTableAsync<ContinentFloorIdEntity>();
        await Connection.CreateTableAsync<ContinentFloorEntity>();
        await Connection.CreateTableAsync<ContinentFloorRegionEntity>();
        await Connection.CreateTableAsync<ContinentFloorMapEntity>();
        await Connection.CreateTableAsync<ContinentFloorGodShrineEntity>();
        await Connection.CreateTableAsync<ContinentFloorPointOfInterestEntity>();
        await Connection.CreateTableAsync<ContinentFloorTaskEntity>();
        await Connection.CreateTableAsync<ContinentFloorTaskBoundsPointEntity>();
        await Connection.CreateTableAsync<ContinentFloorSkillChallengeEntity>();
        await Connection.CreateTableAsync<ContinentFloorSectorEntity>();
        await Connection.CreateTableAsync<ContinentFloorSectorBoundsPointEntity>();
        await Connection.CreateTableAsync<ContinentFloorAdventureEntity>();
        await Connection.CreateTableAsync<ContinentFloorMasteryPointEntity>();
        await Connection.CreateTableAsync<CurrencyEntity>();
        await Connection.CreateTableAsync<DungeonEntity>();
        await Connection.CreateTableAsync<DungeonPathEntity>();
        await Connection.CreateTableAsync<DyeEntity>();
        await Connection.CreateTableAsync<DyeCategoryEntity>();
        await Connection.CreateTableAsync<EmblemComponentEntity>();
        await Connection.CreateTableAsync<EmblemComponentLayerEntity>();
        await Connection.CreateTableAsync<EmoteEntity>();
        await Connection.CreateTableAsync<EmoteCommandEntity>();
        await Connection.CreateTableAsync<EmoteUnlockItemEntity>();
        await Connection.CreateTableAsync<FinisherEntity>();
        await Connection.CreateTableAsync<FinisherUnlockItemEntity>();
        await Connection.CreateTableAsync<GameMapEntity>();
        await Connection.CreateTableAsync<GameMapFloorEntity>();
        await Connection.CreateTableAsync<GliderEntity>();
        await Connection.CreateTableAsync<GliderUnlockItemEntity>();
        await Connection.CreateTableAsync<GliderDefaultDyeEntity>();
        await Connection.CreateTableAsync<HomeCatEntity>();
        await Connection.CreateTableAsync<ItemEntity>();
        await Connection.CreateTableAsync<ItemFlagEntity>();
        await Connection.CreateTableAsync<ItemGameTypeEntity>();
        await Connection.CreateTableAsync<ItemRestrictionEntity>();
        await Connection.CreateTableAsync<ItemUpgradePathEntity>();
        await Connection.CreateTableAsync<ItemDetailsEntity>();
        await Connection.CreateTableAsync<ItemInfusionSlotEntity>();
        await Connection.CreateTableAsync<ItemInfusionSlotFlagEntity>();
        await Connection.CreateTableAsync<ItemStatChoiceEntity>();
        await Connection.CreateTableAsync<ItemInfixUpgradeAttributeEntity>();
        await Connection.CreateTableAsync<ItemExtraRecipeEntity>();
        await Connection.CreateTableAsync<ItemUnlockSkinEntity>();
        await Connection.CreateTableAsync<ItemVendorEntity>();
        await Connection.CreateTableAsync<ItemUpgradeComponentFlagEntity>();
        await Connection.CreateTableAsync<ItemInfusionUpgradeFlagEntity>();
        await Connection.CreateTableAsync<ItemUpgradeComponentBonusEntity>();
        await Connection.CreateTableAsync<ItemStatEntity>();
        await Connection.CreateTableAsync<ItemStatAttributeEntity>();
        await Connection.CreateTableAsync<JadeBotEntity>();
        await Connection.CreateTableAsync<LegendaryArmoryItemEntity>();
        await Connection.CreateTableAsync<LegendEntity>();
        await Connection.CreateTableAsync<LegendUtilityEntity>();
        await Connection.CreateTableAsync<LogoEntity>();
        await Connection.CreateTableAsync<MailCarrierEntity>();
        await Connection.CreateTableAsync<MailCarrierUnlockItemEntity>();
        await Connection.CreateTableAsync<MailCarrierFlagEntity>();
        await Connection.CreateTableAsync<MasteryEntity>();
        await Connection.CreateTableAsync<MasteryLevelEntity>();
        await Connection.CreateTableAsync<MaterialCategoryEntity>();
        await Connection.CreateTableAsync<MaterialCategoryItemEntity>();
        await Connection.CreateTableAsync<MiniEntity>();
        await Connection.CreateTableAsync<NoveltyEntity>();
        await Connection.CreateTableAsync<NoveltyUnlockItemEntity>();
        await Connection.CreateTableAsync<OutfitEntity>();
        await Connection.CreateTableAsync<OutfitUnlockItemEntity>();
        await Connection.CreateTableAsync<PetEntity>();
        await Connection.CreateTableAsync<PetSkillEntity>();
        await Connection.CreateTableAsync<ProfessionEntity>();
        await Connection.CreateTableAsync<ProfessionSpecializationEntity>();
        await Connection.CreateTableAsync<ProfessionFlagEntity>();
        await Connection.CreateTableAsync<ProfessionSkillEntity>();
        await Connection.CreateTableAsync<ProfessionSkillPaletteEntity>();
        await Connection.CreateTableAsync<ProfessionTrainingEntity>();
        await Connection.CreateTableAsync<ProfessionTrainingTrackEntryEntity>();
        await Connection.CreateTableAsync<ProfessionWeaponEntity>();
        await Connection.CreateTableAsync<ProfessionWeaponFlagEntity>();
        await Connection.CreateTableAsync<ProfessionWeaponSkillEntity>();
        await Connection.CreateTableAsync<QuagganEntity>();
        await Connection.CreateTableAsync<RaidEntity>();
        await Connection.CreateTableAsync<RaidWingEntity>();
        await Connection.CreateTableAsync<RaidEventEntity>();
        await Connection.CreateTableAsync<RecipeEntity>();
        await Connection.CreateTableAsync<RecipeProfessionEntity>();
        await Connection.CreateTableAsync<RecipeFlagEntity>();
        await Connection.CreateTableAsync<RecipeIngredientEntity>();
        await Connection.CreateTableAsync<RecipeGuildIngredientEntity>();
        await Connection.CreateTableAsync<SkiffEntity>();
        await Connection.CreateTableAsync<SkiffDyeSlotEntity>();
        await Connection.CreateTableAsync<SkillEntity>();
        await Connection.CreateTableAsync<SkillProfessionEntity>();
        await Connection.CreateTableAsync<SkillCategoryEntity>();
        await Connection.CreateTableAsync<SkillFlagEntity>();
        await Connection.CreateTableAsync<SkillRelatedSkillEntity>();
        await Connection.CreateTableAsync<SkillFactEntity>();
        await Connection.CreateTableAsync<SkinEntity>();
        await Connection.CreateTableAsync<SkinFlagEntity>();
        await Connection.CreateTableAsync<SkinRestrictionEntity>();
        await Connection.CreateTableAsync<SkinDetailsEntity>();
        await Connection.CreateTableAsync<SkinDefaultDyeSlotEntity>();
        await Connection.CreateTableAsync<SpecializationEntity>();
        await Connection.CreateTableAsync<SpecializationTraitEntity>();
        await Connection.CreateTableAsync<StoryEntity>();
        await Connection.CreateTableAsync<StoryChapterEntity>();
        await Connection.CreateTableAsync<StoryRaceEntity>();
        await Connection.CreateTableAsync<StoryFlagEntity>();
        await Connection.CreateTableAsync<StoryJournalEntryEntity>();
        await Connection.CreateTableAsync<StoryGoalEntity>();
        await Connection.CreateTableAsync<StorySeasonEntity>();
        await Connection.CreateTableAsync<StorySeasonStoryEntity>();
        await Connection.CreateTableAsync<TitleEntity>();
        await Connection.CreateTableAsync<TitleAchievementEntity>();
        await Connection.CreateTableAsync<TraitEntity>();
        await Connection.CreateTableAsync<TraitFactEntity>();
        await Connection.CreateTableAsync<TraitSkillEntity>();
        await Connection.CreateTableAsync<TraitSkillFactEntity>();
        await Connection.CreateTableAsync<WorldEntity>();

        // from /v2/achievements
        await Connection.CreateTableAsync<AchievementEntity>();
        await Connection.CreateTableAsync<AchievementFlagEntity>();
        await Connection.CreateTableAsync<AchievementTierEntity>();
        await Connection.CreateTableAsync<AchievementPrerequisiteEntity>();
        await Connection.CreateTableAsync<AchievementRewardEntity>();
        await Connection.CreateTableAsync<AchievementBitEntity>();
        await Connection.CreateTableAsync<AchievementCategoryEntity>();
        await Connection.CreateTableAsync<AchievementCategoryAchievementEntity>();
        await Connection.CreateTableAsync<AchievementCategoryAchievementFlagEntity>();
        await Connection.CreateTableAsync<AchievementDailyEntity>();
        await Connection.CreateTableAsync<AchievementDailyEntryEntity>();
        await Connection.CreateTableAsync<AchievementGroupEntity>();
        await Connection.CreateTableAsync<AchievementGroupCategoryEntity>();

        // from /v2/backstory
        await Connection.CreateTableAsync<BackstoryAnswerEntity>();
        await Connection.CreateTableAsync<BackstoryAnswerProfessionEntity>();
        await Connection.CreateTableAsync<BackstoryAnswerRaceEntity>();
        await Connection.CreateTableAsync<BackstoryQuestionEntity>();
        await Connection.CreateTableAsync<BackstoryQuestionAnswerEntity>();
        await Connection.CreateTableAsync<BackstoryQuestionRaceEntity>();
        await Connection.CreateTableAsync<BackstoryQuestionProfessionEntity>();

        // from /v2/guild
        await Connection.CreateTableAsync<GuildPermissionEntity>();
        await Connection.CreateTableAsync<GuildUpgradeEntity>();
        await Connection.CreateTableAsync<GuildUpgradePrerequisiteEntity>();
        await Connection.CreateTableAsync<GuildUpgradeCostEntity>();

        // from /v2/homestead
        await Connection.CreateTableAsync<HomesteadDecorationCategoryEntity>();
        await Connection.CreateTableAsync<HomesteadDecorationEntity>();
        await Connection.CreateTableAsync<HomesteadDecorationCategoryLinkEntity>();
        await Connection.CreateTableAsync<HomesteadGlyphEntity>();

        // from /v2/mount
        await Connection.CreateTableAsync<MountSkinEntity>();
        await Connection.CreateTableAsync<MountSkinDyeSlotEntity>();
        await Connection.CreateTableAsync<MountTypeEntity>();
        await Connection.CreateTableAsync<MountTypeSkinEntity>();
        await Connection.CreateTableAsync<MountTypeSkillEntity>();

        // from /v2/pvp
        await Connection.CreateTableAsync<PvpAmuletEntity>();
        await Connection.CreateTableAsync<PvpAmuletAttributeEntity>();
        await Connection.CreateTableAsync<PvpHeroEntity>();
        await Connection.CreateTableAsync<PvpHeroSkinEntity>();
        await Connection.CreateTableAsync<PvpHeroSkinUnlockItemEntity>();
        await Connection.CreateTableAsync<PvpRankEntity>();
        await Connection.CreateTableAsync<PvpRankLevelEntity>();

        // from /v2/wvw
        await Connection.CreateTableAsync<WvwAbilityEntity>();
        await Connection.CreateTableAsync<WvwAbilityRankEntity>();
        await Connection.CreateTableAsync<WvwObjectiveEntity>();
        await Connection.CreateTableAsync<WvwRankEntity>();
        await Connection.CreateTableAsync<WvwUpgradeEntity>();
        await Connection.CreateTableAsync<WvwUpgradeTierEntity>();
        await Connection.CreateTableAsync<WvwUpgradeItemEntity>();
    }
}