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

public sealed class Gw2ApiNavigator
{
    private static readonly Lazy<Gw2ApiNavigator> _instance = new(() => new Gw2ApiNavigator());

    private Gw2ApiNavigator()
    {
    }

    public static Gw2ApiNavigator Instance => _instance.Value;

    public Api Api => new();
}

public sealed class Api
{
    public VersionTwo VersionTwo => new();
}

public sealed class VersionTwo
{
    // branches
    public Account Account => new();
    public Achievements Achievements => new();
    public Backstory Backstory => new();
    public Characters Characters => new();
    public Commerce Commerce => new();
    public Emblems Emblems => new();
    public Guild Guild => new();
    public Home Home => new();
    public Homestead Homestead => new();
    public Mounts Mounts => new();
    public Pvp Pvp => new();
    public WizardsVault WizardsVault => new();
    public WvW WvW => new();
    
    // leaves
    public BuildRequest Build => new();
    public ContinentRequest Continent => new();
    public CurrencyRequest Currency => new();
    public DailyCraftingRequest DailyCrafting => new();
    public DungeonRequest Dungeon => new();
    public DyeRequest Dye => new();
    public EmoteRequest Emote => new();
    public FileRequest File => new();
    public FinisherRequest Finisher => new();
    public GliderRequest Glider => new();
    public ItemRequest Item => new();
    public ItemStatRequest ItemStat => new();
    public JadeBotRequest JadeBot => new();
    public LegendaryArmoryRequest LegendaryArmory => new();
    public LegendRequest Legend => new();
    public LogoRequest Logo => new();
    public MailCarrierRequest MailCarrier => new();
    public MapChestRequest MapChest => new();
    public MapRequest Map => new();
    public MasteryRequest Mastery => new();
    public MaterialRequest Material => new();
    public MiniRequest Mini => new();
    public NoveltyRequest Novelty => new();
    public OutfitRequest Outfit => new();
    public PetRequest Pet => new();
    public ProfessionRequest Profession => new();
    public QuagganRequest Quaggan => new();
    public QuestRequest Quest => new();
    public RaceRequest Race => new();
    public RaidRequest Raid => new();
    public RecipeRequest Recipe => new();
    public SkiffRequest Skiff => new();
    public SkillRequest Skill => new();
    public SkinRequest Skin => new();
    public SpecializationRequest Specialization => new();
    public StoryRequest Story => new();
    public StorySeasonRequest StorySeason => new();
    public TitleRequest Title => new();
    public TokenInfoRequest TokenInfo => new();
    public TraitRequest Trait => new();
    public WorldBossRequest WorldBoss => new();
    public WorldRequest World => new();

    public ContinentFloorRequest ContinentFloor(int continentId)
    {
        return new ContinentFloorRequest(continentId);
    }
}

public sealed class Account
{
    public AccountRequest Root => new();
    public AccountAchievementsRequest Achievements => new();
    public AccountBankRequest Bank => new();
    public AccountBuildStorageRequest BuildStorage => new();
    public AccountDailyCraftingRequest DailyCrafting => new();
    public AccountDungeonRequest Dungeon => new();
    public AccountDyeRequest Dye => new();
    public AccountEmoteRequest Emote => new();
    public AccountFinisherRequest Finisher => new();
    public AccountGliderRequest Glider => new();
    public AccountHomeCatRequest HomeCat => new();
    public AccountHomeNodeRequest HomeNode => new();
    public AccountHomesteadDecorationRequest HomesteadDecoration => new();
    public AccountHomesteadGlyphRequest HomesteadGlyph => new();
    public AccountInventoryRequest Inventory => new();
    public AccountJadeBotRequest JadeBot => new();
    public AccountLegendaryArmoryRequest LegendaryArmory => new();
    public AccountLuckRequest Luck => new();
    public AccountMailCarrierRequest MailCarrier => new();
    public AccountMapChestRequest MapChest => new();
    public AccountMasteryPointsRequest MasteryPoints => new();
    public AccountMasteryRequest Mastery => new();
    public AccountMaterialRequest Material => new();
    public AccountMiniRequest Mini => new();
    public AccountMountSkinRequest MountSkin => new();
    public AccountMountTypeRequest MountType => new();
    public AccountNoveltyRequest Novelty => new();
    public AccountOutfitRequest Outfit => new();
    public AccountProgressionRequest Progression => new();
    public AccountPvpHeroRequest PvpHero => new();
    public AccountRaidRequest Raid => new();
    public AccountRecipeRequest Recipe => new();
    public AccountSkiffRequest Skiff => new();
    public AccountSkinRequest Skin => new();
    public AccountTitleRequest Title => new();
    public AccountWalletRequest Wallet => new();
    public AccountWizardsVaultDailyRequest WizardsVaultDaily => new();
    public AccountWizardsVaultListingRequest WizardsVaultListing => new();
    public AccountWizardsVaultSpecialRequest WizardsVaultSpecial => new();
    public AccountWizardsVaultWeeklyRequest WizardsVaultWeekly => new();
    public AccountWorldBossRequest WorldBoss => new();
    public AccountWvwRequest Wvw => new();
}

public sealed class Achievements
{
    public AchievementRequest Root => new();
    public AchievementCategoryRequest Category => new();
    public AchievementDailyRequest Daily => new();
    public AchievementDailyTomorrowRequest DailyTomorrow => new();
    public AchievementGroupRequest Group => new();
}

public sealed class Backstory
{
    public BackstoryAnswerRequest Answer => new();
    public BackstoryQuestionRequest Question => new();
}

public sealed class Characters
{
    public CharactersRequest Root => new();

    public CharacterBackstoryRequest Backstory(string characterName)
    {
        return new CharacterBackstoryRequest(characterName);
    }

    public CharacterBuildTabRequest BuildTab(string characterName)
    {
        return new CharacterBuildTabRequest(characterName);
    }

    public CharacterCoreRequest CharacterCore(string characterName)
    {
        return new CharacterCoreRequest(characterName);
    }

    public CharacterCraftingRequest Crafting(string characterName)
    {
        return new CharacterCraftingRequest(characterName);
    }

    public CharacterEquipmentRequest Equipment(string characterName)
    {
        return new CharacterEquipmentRequest(characterName);
    }

    public CharacterEquipmentTabRequest EquipmentTab(string characterName)
    {
        return new CharacterEquipmentTabRequest(characterName);
    }

    public CharacterHeroPointsRequest HeroPoints(string characterName)
    {
        return new CharacterHeroPointsRequest(characterName);
    }

    public CharacterInventoryRequest Inventory(string characterName)
    {
        return new CharacterInventoryRequest(characterName);
    }

    public CharacterQuestRequest Quest(string characterName)
    {
        return new CharacterQuestRequest(characterName);
    }

    public CharacterRecipesRequest Recipes(string characterName)
    {
        return new CharacterRecipesRequest(characterName);
    }

    public CharacterSabRequest Sab(string characterName)
    {
        return new CharacterSabRequest(characterName);
    }

    public CharacterSkillsRequest Skills(string characterName)
    {
        return new CharacterSkillsRequest(characterName);
    }

    public CharacterSpecializationsRequest Specializations(string characterName)
    {
        return new CharacterSpecializationsRequest(characterName);
    }

    public CharacterTrainingRequest Training(string characterName)
    {
        return new CharacterTrainingRequest(characterName);
    }
}

public sealed class Commerce
{
    public CommerceCurrentBuysRequest CurrentBuys => new();
    public CommerceCurrentSellsRequest CurrentSells => new();
    public CommerceDeliveryRequest Delivery => new();
    public CommerceExchangeCoinsRequest ExchangeCoins => new();
    public CommerceExchangeGemsRequest ExchangeGems => new();
    public CommerceHistoryBuysRequest HistoryBuys => new();
    public CommerceHistorySellsRequest HistorySells => new();
    public CommerceListingRequest Listing => new();
    public CommercePriceRequest Price => new();
}

public sealed class Emblems
{
    public EmblemBackgroundRequest Background => new();
    public EmblemForegroundRequest Foreground => new();
}

public sealed class Guild
{
    public GuildPermissionRequest Permission => new();
    public GuildSearchRequest Search => new();
    public GuildUpgradesRequest Upgrades => new();

    public GuildLogRequest Log(string guildId)
    {
        return new GuildLogRequest(guildId);
    }

    public GuildMemberRequest Member(string guildId)
    {
        return new GuildMemberRequest(guildId);
    }

    public GuildOverviewRequest Overview(string guildId)
    {
        return new GuildOverviewRequest(guildId);
    }

    public GuildOwnedUpgradesRequest OwnedUpgrades(string guildId)
    {
        return new GuildOwnedUpgradesRequest(guildId);
    }

    public GuildRankRequest Rank(string guildId)
    {
        return new GuildRankRequest(guildId);
    }

    public GuildStashRequest Stash(string guildId)
    {
        return new GuildStashRequest(guildId);
    }

    public GuildStorageRequest Storage(string guildId)
    {
        return new GuildStorageRequest(guildId);
    }

    public GuildTeamRequest Team(string guildId)
    {
        return new GuildTeamRequest(guildId);
    }

    public GuildTreasuryRequest Treasury(string guildId)
    {
        return new GuildTreasuryRequest(guildId);
    }
}

public sealed class Home
{
    public HomeCatRequest Cat => new();
    public HomeNodeRequest Node => new();
}

public sealed class Homestead
{
    public HomesteadDecorationCategoryRequest DecorationCategory => new();
    public HomesteadDecorationRequest Decoration => new();
    public HomesteadGlyphRequest Glyph => new();
}

public sealed class Mounts
{
    public MountSkinRequest Skin => new();
    public MountTypeRequest Type => new();
}

public sealed class Pvp
{
    public PvpAmuletRequest Amulet => new();
    public PvpGameRequest Game => new();
    public PvpHeroRequest Hero => new();
    public PvpRankRequest Rank => new();
    public PvpSeasonRequest Season => new();
    public PvpStandingRequest Standing => new();
    public PvpStatsRequest Stats => new();
}

public sealed class WizardsVault
{
    public WizardsVaultRequest Root => new();
    public WizardsVaultListingRequest Listing => new();
    public WizardsVaultObjectiveRequest Objective => new();
}

public sealed class WvW
{
    public WvwAbilityRequest Ability => new();
    public WvwMatchRequest Match => new();
    public WvwMatchWorldOverviewRequest MatchWorldOverview => new();
    public WvwMatchWorldScoresRequest MatchWorldScores => new();
    public WvwMatchWorldStatsRequest MatchWorldStats => new();
    public WvwRankRequest Rank => new();
    public WvwObjectiveRequest Objective => new();
    public WvwTimerLockoutRequest TimerLockout => new();
    public WvwTimerTeamAssignmentRequest TimerTeamAssignment => new();
    public WvwEuGuildsRequest EuGuilds => new();
    public WvwNaGuildsRequest NaGuilds => new();
    public WvwUpgradeRequest Upgrade => new();
}