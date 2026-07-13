using AsuraGate.Gateway;
using AsuraGate.Spec.Requests;
using AsuraGate.Spec.Requests.V2.Emblem;
using AsuraGate.StaticCache;
using AsuraGate.StaticCache.Repositories.V2;
using AsuraGate.StaticCache.Repositories.V2.Achievements;
using AsuraGate.StaticCache.Repositories.V2.Backstory;
using AsuraGate.StaticCache.Repositories.V2.Guild;
using AsuraGate.StaticCache.Repositories.V2.Homestead;
using AsuraGate.StaticCache.Repositories.V2.Mount;
using AsuraGate.StaticCache.Repositories.V2.Pvp;
using AsuraGate.StaticCache.Repositories.V2.Wvw;
using AsuraGate.Sync.Providers.V2;
using AsuraGate.Sync.Providers.V2.Achievements;
using AsuraGate.Sync.Providers.V2.Backstory;
using AsuraGate.Sync.Providers.V2.Guild;
using AsuraGate.Sync.Providers.V2.Homestead;
using AsuraGate.Sync.Providers.V2.Mount;
using AsuraGate.Sync.Providers.V2.Pvp;
using AsuraGate.Sync.Providers.V2.Wvw;

namespace AsuraGate.Sync;

public class ProviderLink
{
    private readonly Gw2ApiStaticCacheDatabase _database;
    private readonly Gw2ApiGateway _gateway;

    internal ProviderLink(Gw2ApiStaticCacheDatabase database, Gw2ApiGateway gateway)
    {
        _database = database;
        _gateway = gateway;
    }

    // leaves
    public ApiFileProvider ApiFile => new(new ApiFileRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.File, _gateway);
    public ContinentProvider Continent => new(new ContinentRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Continent, _gateway);
    public CurrencyProvider Currency => new(new CurrencyRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Currency, _gateway);
    public DungeonProvider Dungeon => new(new DungeonRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Dungeon, _gateway);
    public DyeProvider Dye => new(new DyeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Dye, _gateway);
    public EmoteProvider Emote => new(new EmoteRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Emote, _gateway);
    public FinisherProvider Finisher => new(new FinisherRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Finisher, _gateway);
    public GameMapProvider GameMap => new(new GameMapRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Map, _gateway);
    public GliderProvider Glider => new(new GliderRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Glider, _gateway);
    public HomeCatProvider HomeCat => new(new HomeCatRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Home.Cat, _gateway);
    public ItemProvider Item => new(new ItemRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Item, _gateway);
    public ItemStatProvider ItemStat => new(new ItemStatRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.ItemStat, _gateway);
    public JadeBotProvider JadeBot => new(new JadeBotRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.JadeBot, _gateway);
    public LegendProvider Legend => new(new LegendRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Legend, _gateway);
    public LegendaryArmoryItemProvider LegendaryArmoryItem => new(new LegendaryArmoryItemRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.LegendaryArmory, _gateway);
    public LogoProvider Logo => new(new LogoRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Logo, _gateway);
    public MailCarrierProvider MailCarrier => new(new MailCarrierRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.MailCarrier, _gateway);
    public MasteryProvider Mastery => new(new MasteryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Mastery, _gateway);
    public MaterialCategoryProvider MaterialCategory => new(new MaterialCategoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Material, _gateway);
    public MiniProvider Mini => new(new MiniRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Mini, _gateway);
    public NoveltyProvider Novelty => new(new NoveltyRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Novelty, _gateway);
    public OutfitProvider Outfit => new(new OutfitRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Outfit, _gateway);
    public PetProvider Pet => new(new PetRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Pet, _gateway);
    public ProfessionProvider Profession => new(new ProfessionRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Profession, _gateway);
    public QuagganProvider Quaggan => new(new QuagganRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Quaggan, _gateway);
    public RaidProvider Raid => new(new RaidRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Raid, _gateway);
    public RecipeProvider Recipe => new(new RecipeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Recipe, _gateway);
    public SkiffProvider Skiff => new(new SkiffRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Skiff, _gateway);
    public SkillProvider Skill => new(new SkillRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Skill, _gateway);
    public SkinProvider Skin => new(new SkinRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Skin, _gateway);
    public SpecializationProvider Specialization => new(new SpecializationRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Specialization, _gateway);
    public StoryProvider Story => new(new StoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Story, _gateway);
    public StoryJournalEntryProvider StoryJournalEntry => new(new StoryJournalEntryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Quest, _gateway);
    public StorySeasonProvider StorySeason => new(new StorySeasonRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.StorySeason, _gateway);
    public TitleProvider Title => new(new TitleRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Title, _gateway);
    public TraitProvider Trait => new(new TraitRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Trait, _gateway);
    public WorldProvider World => new(new WorldRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.World, _gateway);

    public ContinentFloorProvider ContinentFloor(int continentId) => new(new ContinentFloorRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.ContinentFloor(continentId), _gateway);
    public BuildProvider Build => new(new BuildRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Build, _gateway);
    public EmblemComponentProvider<EmblemBackgroundRequest> EmblemBackground => new("background", new EmblemComponentRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Emblems.Background, _gateway);
    public EmblemComponentProvider<EmblemForegroundRequest> EmblemForeground => new("foreground", new EmblemComponentRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Emblems.Foreground, _gateway);

    // branches
    public AchievementsProviders Achievements => new(_database, _gateway);
    public BackstoryProviders Backstory => new(_database, _gateway);
    public GuildProviders Guild => new(_database, _gateway);
    public HomesteadProviders Homestead => new(_database, _gateway);
    public MountProviders Mount => new(_database, _gateway);
    public PvpProviders Pvp => new(_database, _gateway);
    public WvwProviders Wvw => new(_database, _gateway);
}

public class AchievementsProviders
{
    private readonly Gw2ApiStaticCacheDatabase _database;
    private readonly Gw2ApiGateway _gateway;

    internal AchievementsProviders(Gw2ApiStaticCacheDatabase database, Gw2ApiGateway gateway)
    {
        _database = database;
        _gateway = gateway;
    }

    public AchievementProvider Root => new(new AchievementRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Achievements.Root, _gateway);
    public AchievementCategoryProvider Category => new(new AchievementCategoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Achievements.Category, _gateway);
    public AchievementGroupProvider Group => new(new AchievementGroupRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Achievements.Group, _gateway);
    public AchievementDailyProvider Daily => new(new AchievementDailyRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Achievements.Daily, _gateway);
}

public class BackstoryProviders
{
    private readonly Gw2ApiStaticCacheDatabase _database;
    private readonly Gw2ApiGateway _gateway;

    internal BackstoryProviders(Gw2ApiStaticCacheDatabase database, Gw2ApiGateway gateway)
    {
        _database = database;
        _gateway = gateway;
    }

    public BackstoryAnswerProvider Answer => new(new BackstoryAnswerRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Backstory.Answer, _gateway);
    public BackstoryQuestionProvider Question => new(new BackstoryQuestionRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Backstory.Question, _gateway);
}

public class GuildProviders
{
    private readonly Gw2ApiStaticCacheDatabase _database;
    private readonly Gw2ApiGateway _gateway;

    internal GuildProviders(Gw2ApiStaticCacheDatabase database, Gw2ApiGateway gateway)
    {
        _database = database;
        _gateway = gateway;
    }

    public GuildPermissionProvider Permission => new(new GuildPermissionRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Guild.Permission, _gateway);
    public GuildUpgradeProvider Upgrade => new(new GuildUpgradeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Guild.Upgrades, _gateway);
}

public class HomesteadProviders
{
    private readonly Gw2ApiStaticCacheDatabase _database;
    private readonly Gw2ApiGateway _gateway;

    internal HomesteadProviders(Gw2ApiStaticCacheDatabase database, Gw2ApiGateway gateway)
    {
        _database = database;
        _gateway = gateway;
    }

    public HomesteadDecorationProvider Decoration => new(new HomesteadDecorationRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Homestead.Decoration, _gateway);
    public HomesteadDecorationCategoryProvider DecorationCategory => new(new HomesteadDecorationCategoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Homestead.DecorationCategory, _gateway);
    public HomesteadGlyphProvider Glyph => new(new HomesteadGlyphRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Homestead.Glyph, _gateway);
}

public class MountProviders
{
    private readonly Gw2ApiStaticCacheDatabase _database;
    private readonly Gw2ApiGateway _gateway;

    internal MountProviders(Gw2ApiStaticCacheDatabase database, Gw2ApiGateway gateway)
    {
        _database = database;
        _gateway = gateway;
    }

    public MountSkinProvider Skin => new(new MountSkinRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Mounts.Skin, _gateway);
    public MountTypeProvider Type => new(new MountTypeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Mounts.Type, _gateway);
}

public class PvpProviders
{
    private readonly Gw2ApiStaticCacheDatabase _database;
    private readonly Gw2ApiGateway _gateway;

    internal PvpProviders(Gw2ApiStaticCacheDatabase database, Gw2ApiGateway gateway)
    {
        _database = database;
        _gateway = gateway;
    }

    public PvpAmuletProvider Amulet => new(new PvpAmuletRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Pvp.Amulet, _gateway);
    public PvpHeroProvider Hero => new(new PvpHeroRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Pvp.Hero, _gateway);
    public PvpRankProvider Rank => new(new PvpRankRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Pvp.Rank, _gateway);
}

public class WvwProviders
{
    private readonly Gw2ApiStaticCacheDatabase _database;
    private readonly Gw2ApiGateway _gateway;

    internal WvwProviders(Gw2ApiStaticCacheDatabase database, Gw2ApiGateway gateway)
    {
        _database = database;
        _gateway = gateway;
    }

    public WvwAbilityProvider Ability => new(new WvwAbilityRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Ability, _gateway);
    public WvwObjectiveProvider Objective => new(new WvwObjectiveRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Objective, _gateway);
    public WvwRankProvider Rank => new(new WvwRankRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Rank, _gateway);
    public WvwUpgradeProvider Upgrade => new(new WvwUpgradeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Upgrade, _gateway);
}
