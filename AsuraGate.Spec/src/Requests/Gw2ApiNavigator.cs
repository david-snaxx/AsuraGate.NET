using AsuraGate.Spec.Requests.V2;
using AsuraGate.Spec.Requests.V2.Account;
using AsuraGate.Spec.Requests.V2.Achievements;
using AsuraGate.Spec.Requests.V2.Backstory;
using AsuraGate.Spec.Requests.V2.Character;
using AsuraGate.Spec.Requests.V2.Commerce;
using AsuraGate.Spec.Requests.V2.Emblem;
using AsuraGate.Spec.Requests.V2.Guild;
using AsuraGate.Spec.Requests.V2.Home;
using AsuraGate.Spec.Requests.V2.Homestead;
using AsuraGate.Spec.Requests.V2.Mount;
using AsuraGate.Spec.Requests.V2.Pvp;
using AsuraGate.Spec.Requests.V2.WizardsVault;
using AsuraGate.Spec.Requests.V2.Wvw;

namespace AsuraGate.Spec.Requests;

public static class Gw2ApiNavigator
{
    
    public static class Api
    {
        public static class VersionTwo
        {
            public static class Account
            {
                public static AccountRequest Root => new();
                public static AccountAchievementsRequest Achievements => new();
                public static AccountBankRequest Bank => new();
                public static AccountBuildStorageRequest BuildStorage => new();
                public static AccountDailyCraftingRequest DailyCrafting => new();
                public static AccountDungeonRequest Dungeon => new();
                public static AccountDyeRequest Dye => new();
                public static AccountEmoteRequest Emote => new();
                public static AccountFinisherRequest Finisher => new();
                public static AccountGliderRequest Glider => new();
                public static AccountHomeCatRequest HomeCat => new();
                public static AccountHomeNodeRequest HomeNode => new();
                public static AccountHomesteadDecorationRequest HomesteadDecoration => new();
                public static AccountHomesteadGlyphRequest HomesteadGlyph => new();
                public static AccountInventoryRequest Inventory => new();
                public static AccountJadeBotRequest JadeBot => new();
                public static AccountLegendaryArmoryRequest LegendaryArmory => new();
                public static AccountLuckRequest Luck => new();
                public static AccountMailCarrierRequest MailCarrier => new();
                public static AccountMapChestRequest MapChest => new();
                public static AccountMasteryPointsRequest MasteryPoints => new();
                public static AccountMasteryRequest Mastery => new();
                public static AccountMaterialRequest Material => new();
                public static AccountMiniRequest Mini => new();
                public static AccountMountSkinRequest MountSkin => new();
                public static AccountMountTypeRequest MountType => new();
                public static AccountNoveltyRequest Novelty => new();
                public static AccountOutfitRequest Outfit => new();
                public static AccountProgressionRequest Progression => new();
                public static AccountPvpHeroRequest PvpHero => new();
                public static AccountRaidRequest Raid => new();
                public static AccountRecipeRequest Recipe => new();
                public static AccountSkiffRequest Skiff => new();
                public static AccountSkinRequest Skin => new();
                public static AccountTitleRequest Title => new();
                public static AccountWalletRequest Wallet => new();
                public static AccountWizardsVaultDailyRequest WizardsVaultDaily => new();
                public static AccountWizardsVaultListingRequest WizardsVaultListing => new();
                public static AccountWizardsVaultSpecialRequest WizardsVaultSpecial => new();
                public static AccountWizardsVaultWeeklyRequest WizardsVaultWeekly => new();
                public static AccountWorldBossRequest WorldBoss => new();
                public static AccountWvwRequest Wvw => new();
            }

            public static class Achievements
            {
                public static AchievementRequest Root => new();
                public static AchievementCategoryRequest Category => new();
                public static AchievementDailyRequest Daily => new();
                public static AchievementDailyTomorrowRequest DailyTomorrow => new();
                public static AchievementGroupRequest Group => new();
            }

            public static class Backstory
            {
                public static BackstoryAnswerRequest Answer => new();
                public static BackstoryQuestionRequest Question => new();
            }

            public static class Characters
            {
                public static CharactersRequest Root => new();
                public static CharacterBackstoryRequest Backstory(string characterName) => new(characterName);
                public static CharacterBuildTabRequest BuildTab(string characterName) => new(characterName);
                public static CharacterCoreRequest CharacterCore(string characterName) => new(characterName);
                public static CharacterCraftingRequest Crafting(string characterName) => new(characterName);
                public static CharacterEquipmentRequest Equipment(string characterName) => new(characterName);
                public static CharacterEquipmentTabRequest EquipmentTab(string characterName) => new(characterName);
                public static CharacterHeroPointsRequest HeroPoints(string characterName) => new(characterName);
                public static CharacterInventoryRequest Inventory(string characterName) => new(characterName);
                public static CharacterQuestRequest Quest(string characterName) => new(characterName);
                public static CharacterRecipesRequest Recipes(string characterName) => new(characterName);
                public static CharacterSabRequest Sab(string characterName) => new(characterName);
                public static CharacterSkillsRequest Skills(string characterName) => new(characterName);
                public static CharacterSpecializationsRequest Specializations(string characterName) => new(characterName);
                public static CharacterTrainingRequest Training(string characterName) => new(characterName);
            }

            public static class Commerce
            {
                public static CommerceCurrentBuysRequest CurrentBuys => new();
                public static CommerceCurrentSellsRequest CurrentSells => new();
                public static CommerceDeliveryRequest Delivery => new();
                public static CommerceExchangeCoinsRequest ExchangeCoins => new();
                public static CommerceExchangeGemsRequest ExchangeGems => new();
                public static CommerceHistoryBuysRequest HistoryBuys => new();
                public static CommerceHistorySellsRequest HistorySells => new();
                public static CommerceListingRequest Listing => new();
                public static CommercePriceRequest Price => new();
            }

            public static class Emblems
            {
                public static EmblemBackgroundRequest Background => new();
                public static EmblemForegroundRequest Foreground => new();
            }

            public static class Guild
            {
                public static GuildLogRequest Log(string guildId) => new(guildId);
                public static GuildMemberRequest Member(string guildId) => new(guildId);
                public static GuildOverviewRequest Overview(string guildId) => new(guildId);
                public static GuildOwnedUpgradesRequest OwnedUpgrades(string guildId) => new(guildId);
                public static GuildRankRequest Rank(string guildId) => new(guildId);
                public static GuildStashRequest Stash(string guildId) => new(guildId);
                public static GuildStorageRequest Storage(string guildId) => new(guildId);
                public static GuildTeamRequest Team(string guildId) => new(guildId);
                public static GuildTreasuryRequest Treasury(string guildId) => new(guildId);
                public static GuildPermissionRequest Permission => new();
                public static GuildSearchRequest Search => new();
                public static GuildUpgradesRequest Upgrades => new();
            }

            public static class Home
            {
                public static HomeCatRequest Cat => new();
                public static HomeNodeRequest Node => new();
            }

            public static class Homestead
            {
                public static HomesteadDecorationCategoryRequest DecorationCategory => new();
                public static HomesteadDecorationRequest Decoration => new();
                public static HomesteadGlyphRequest Glyph => new();
            }

            public static class Mounts
            {
                public static MountSkinRequest Skin => new();
                public static MountTypeRequest Type => new();
            }

            public static class Pvp
            {
                public static PvpAmuletRequest Amulet => new();
                public static PvpGameRequest Game => new();
                public static PvpHeroRequest Hero => new();
                public static PvpRankRequest Rank => new();
                public static PvpSeasonRequest Season => new();
                public static PvpStandingRequest Standing => new();
                public static PvpStatsRequest Stats => new();
            }

            public static class WizardsVault
            {
                public static WizardsVaultRequest Root => new();
                public static WizardsVaultListingRequest Listing => new();
                public static WizardsVaultObjectiveRequest Objective => new();
            }

            public static class WvW
            {
                public static WvwAbilityRequest Ability => new();
                public static WvwMatchRequest Match => new();
                public static WvwMatchWorldOverviewRequest MatchWorldOverview => new();
                public static WvwMatchWorldScoresRequest MatchWorldScores => new();
                public static WvwMatchWorldStatsRequest MatchWorldStats => new();
                public static WvwRankRequest Rank => new();
                public static WvwObjectiveRequest Objective => new();
                public static WvwTimerLockoutRequest TimerLockout => new();
                public static WvwTimerTeamAssignmentRequest TimerTeamAssignment => new();
                public static WvwEuGuildsRequest EuGuilds => new();
                public static WvwNaGuildsRequest NaGuilds => new();
                public static WvwUpgradeRequest Upgrade => new();
            }
            
            public static BuildRequest Build => new();
            public static ContinentFloorRequest ContinentFloor(int continentId) => new(continentId);
            public static ContinentRequest Continent => new();
            public static CurrencyRequest Currency => new();
            public static DailyCraftingRequest DailyCrafting => new();
            public static DungeonRequest Dungeon => new();
            public static DyeRequest Dye => new();
            public static EmoteRequest Emote => new();
            public static FileRequest File => new();
            public static FinisherRequest Finisher => new();
            public static GliderRequest Glider => new();
            public static ItemRequest Item => new();
            public static ItemStatRequest ItemStat => new();
            public static JadeBotRequest JadeBot => new();
            public static LegendaryArmoryRequest LegendaryArmory => new();
            public static LegendRequest Legend => new();
            public static LogoRequest Logo => new();
            public static MailCarrierRequest MailCarrier => new();
            public static MapChestRequest MapChest => new();
            public static MapRequest Map => new();
            public static MasteryRequest Mastery => new();
            public static MaterialRequest Material => new();
            public static MiniRequest Mini => new();
            public static NoveltyRequest Novelty => new();
            public static OutfitRequest Outfit => new();
            public static PetRequest Pet => new();
            public static ProfessionRequest Profession => new();
            public static QuagganRequest Quaggan => new();
            public static QuestRequest Quest => new();
            public static RaceRequest Race => new();
            public static RaidRequest Raid => new();
            public static RecipeRequest Recipe => new();
            public static SkiffRequest Skiff => new();
            public static SkillRequest Skill => new();
            public static SkinRequest Skin => new();
            public static SpecializationRequest Specialization => new();
            public static StoryRequest Story => new();
            public static StorySeasonRequest StorySeason => new();
            public static TitleRequest Title => new();
            public static TokenInfoRequest TokenInfo => new();
            public static TraitRequest Trait => new();
            public static WorldBossRequest WorldBoss => new();
            public static WorldRequest World => new();
        }
    }
}
