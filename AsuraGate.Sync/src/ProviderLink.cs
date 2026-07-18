using AsuraGate.Gateway;
using AsuraGate.Spec.Requests;
using AsuraGate.Persistence;
using AsuraGate.Persistence.Static.Meta;
using AsuraGate.Persistence.Static.Repositories.V2;
using AsuraGate.Persistence.Static.Repositories.V2.Achievements;
using AsuraGate.Persistence.Static.Repositories.V2.Backstory;
using AsuraGate.Persistence.Static.Repositories.V2.Guild;
using AsuraGate.Persistence.Static.Repositories.V2.Homestead;
using AsuraGate.Persistence.Static.Repositories.V2.Mount;
using AsuraGate.Persistence.Static.Repositories.V2.Pvp;
using AsuraGate.Persistence.Static.Repositories.V2.Wvw;
using AsuraGate.Sync.Providers.V2;
using AsuraGate.Sync.Providers.V2.Achievements;
using AsuraGate.Sync.Providers.V2.Backstory;
using AsuraGate.Sync.Providers.V2.Guild;
using AsuraGate.Sync.Providers.V2.Homestead;
using AsuraGate.Sync.Providers.V2.Mount;
using AsuraGate.Sync.Providers.V2.Pvp;
using AsuraGate.Sync.Providers.V2.Wvw;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync;

public class ProviderLink : ProviderBase
{
    internal ProviderLink(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway, ILogger logger)
        : base(database, gateway, new StaticMetaRepository(database), logger)
    {
    }

    // leaves
    public ApiFileProvider ApiFile => new(new ApiFileRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.File, _gateway, _staticMetaRepository, _logger);
    public ContinentProvider Continent => new(new ContinentRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Continent, _gateway, _staticMetaRepository, _logger);
    public CurrencyProvider Currency => new(new CurrencyRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Currency, _gateway, _staticMetaRepository, _logger);
    public DungeonProvider Dungeon => new(new DungeonRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Dungeon, _gateway, _staticMetaRepository, _logger);
    public DyeProvider Dye => new(new DyeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Dye, _gateway, _staticMetaRepository, _logger);
    public EmoteProvider Emote => new(new EmoteRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Emote, _gateway, _staticMetaRepository, _logger);
    public FinisherProvider Finisher => new(new FinisherRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Finisher, _gateway, _staticMetaRepository, _logger);
    public GameMapProvider GameMap => new(new GameMapRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Map, _gateway, _staticMetaRepository, _logger);
    public GliderProvider Glider => new(new GliderRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Glider, _gateway, _staticMetaRepository, _logger);
    public HomeCatProvider HomeCat => new(new HomeCatRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Home.Cat, _gateway, _staticMetaRepository, _logger);
    public ItemProvider Item => new(new ItemRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Item, _gateway, _staticMetaRepository, _logger);
    public ItemStatProvider ItemStat => new(new ItemStatRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.ItemStat, _gateway, _staticMetaRepository, _logger);
    public JadeBotProvider JadeBot => new(new JadeBotRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.JadeBot, _gateway, _staticMetaRepository, _logger);
    public LegendProvider Legend => new(new LegendRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Legend, _gateway, _staticMetaRepository, _logger);
    public LegendaryArmoryItemProvider LegendaryArmoryItem => new(new LegendaryArmoryItemRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.LegendaryArmory, _gateway, _staticMetaRepository, _logger);
    public LogoProvider Logo => new(new LogoRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Logo, _gateway, _staticMetaRepository, _logger);
    public MailCarrierProvider MailCarrier => new(new MailCarrierRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.MailCarrier, _gateway, _staticMetaRepository, _logger);
    public MasteryProvider Mastery => new(new MasteryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Mastery, _gateway, _staticMetaRepository, _logger);
    public MaterialCategoryProvider MaterialCategory => new(new MaterialCategoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Material, _gateway, _staticMetaRepository, _logger);
    public MiniProvider Mini => new(new MiniRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Mini, _gateway, _staticMetaRepository, _logger);
    public NoveltyProvider Novelty => new(new NoveltyRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Novelty, _gateway, _staticMetaRepository, _logger);
    public OutfitProvider Outfit => new(new OutfitRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Outfit, _gateway, _staticMetaRepository, _logger);
    public PetProvider Pet => new(new PetRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Pet, _gateway, _staticMetaRepository, _logger);
    public ProfessionProvider Profession => new(new ProfessionRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Profession, _gateway, _staticMetaRepository, _logger);
    public QuagganProvider Quaggan => new(new QuagganRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Quaggan, _gateway, _staticMetaRepository, _logger);
    public RaidProvider Raid => new(new RaidRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Raid, _gateway, _staticMetaRepository, _logger);
    public RecipeProvider Recipe => new(new RecipeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Recipe, _gateway, _staticMetaRepository, _logger);
    public SkiffProvider Skiff => new(new SkiffRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Skiff, _gateway, _staticMetaRepository, _logger);
    public SkillProvider Skill => new(new SkillRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Skill, _gateway, _staticMetaRepository, _logger);
    public SkinProvider Skin => new(new SkinRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Skin, _gateway, _staticMetaRepository, _logger);
    public SpecializationProvider Specialization => new(new SpecializationRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Specialization, _gateway, _staticMetaRepository, _logger);
    public StoryProvider Story => new(new StoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Story, _gateway, _staticMetaRepository, _logger);
    public StoryJournalEntryProvider StoryJournalEntry => new(new StoryJournalEntryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Quest, _gateway, _staticMetaRepository, _logger);
    public StorySeasonProvider StorySeason => new(new StorySeasonRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.StorySeason, _gateway, _staticMetaRepository, _logger);
    public TitleProvider Title => new(new TitleRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Title, _gateway, _staticMetaRepository, _logger);
    public TraitProvider Trait => new(new TraitRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Trait, _gateway, _staticMetaRepository, _logger);
    public WorldProvider World => new(new WorldRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.World, _gateway, _staticMetaRepository, _logger);

    public ContinentFloorProvider ContinentFloor(int continentId) => new(new ContinentFloorRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.ContinentFloor(continentId), _gateway, _staticMetaRepository, _logger);
    public EmblemBackgroundProvider EmblemBackground => new(new EmblemBackgroundRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Emblems.Background, _gateway, _staticMetaRepository, _logger);
    public EmblemForegroundProvider EmblemForeground => new(new EmblemForegroundRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Emblems.Foreground, _gateway, _staticMetaRepository, _logger);

    // branches
    public AchievementsProviders Achievements => new(_database, _gateway, _staticMetaRepository, _logger);
    public BackstoryProviders Backstory => new(_database, _gateway, _staticMetaRepository, _logger);
    public GuildProviders Guild => new(_database, _gateway, _staticMetaRepository, _logger);
    public HomesteadProviders Homestead => new(_database, _gateway, _staticMetaRepository, _logger);
    public MountProviders Mount => new(_database, _gateway, _staticMetaRepository, _logger);
    public PvpProviders Pvp => new(_database, _gateway, _staticMetaRepository, _logger);
    public WvwProviders Wvw => new(_database, _gateway, _staticMetaRepository, _logger);
}

public class AchievementsProviders : ProviderBase
{
    internal AchievementsProviders(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway,
        StaticMetaRepository staticMetaRepository, ILogger logger) : base(database, gateway, staticMetaRepository,
        logger)
    {
    }

    public AchievementProvider Root => new(new AchievementRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Achievements.Root, _gateway, _staticMetaRepository, _logger);
    public AchievementCategoryProvider Category => new(new AchievementCategoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Achievements.Category, _gateway, _staticMetaRepository, _logger);
    public AchievementGroupProvider Group => new(new AchievementGroupRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Achievements.Group, _gateway, _staticMetaRepository, _logger);
}

public class BackstoryProviders : ProviderBase
{
    internal BackstoryProviders(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway,
        StaticMetaRepository staticMetaRepository, ILogger logger) : base(database, gateway, staticMetaRepository,
        logger)
    {
    }

    public BackstoryAnswerProvider Answer => new(new BackstoryAnswerRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Backstory.Answer, _gateway, _staticMetaRepository, _logger);
    public BackstoryQuestionProvider Question => new(new BackstoryQuestionRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Backstory.Question, _gateway, _staticMetaRepository, _logger);
}

public class GuildProviders : ProviderBase
{
    internal GuildProviders(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway,
        StaticMetaRepository staticMetaRepository, ILogger logger) : base(database, gateway, staticMetaRepository,
        logger)
    {
    }

    public GuildPermissionProvider Permission => new(new GuildPermissionRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Guild.Permission, _gateway, _staticMetaRepository, _logger);
    public GuildUpgradeProvider Upgrade => new(new GuildUpgradeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Guild.Upgrades, _gateway, _staticMetaRepository, _logger);
}

public class HomesteadProviders : ProviderBase
{
    internal HomesteadProviders(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway,
        StaticMetaRepository staticMetaRepository, ILogger logger) : base(database, gateway, staticMetaRepository,
        logger)
    {
    }

    public HomesteadDecorationProvider Decoration => new(new HomesteadDecorationRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Homestead.Decoration, _gateway, _staticMetaRepository, _logger);
    public HomesteadDecorationCategoryProvider DecorationCategory => new(new HomesteadDecorationCategoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Homestead.DecorationCategory, _gateway, _staticMetaRepository, _logger);
    public HomesteadGlyphProvider Glyph => new(new HomesteadGlyphRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Homestead.Glyph, _gateway, _staticMetaRepository, _logger);
}

public class MountProviders : ProviderBase
{
    internal MountProviders(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway,
        StaticMetaRepository staticMetaRepository, ILogger logger) : base(database, gateway, staticMetaRepository,
        logger)
    {
    }

    public MountSkinProvider Skin => new(new MountSkinRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Mounts.Skin, _gateway, _staticMetaRepository, _logger);
    public MountTypeProvider Type => new(new MountTypeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Mounts.Type, _gateway, _staticMetaRepository, _logger);
}

public class PvpProviders : ProviderBase
{
    internal PvpProviders(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway,
        StaticMetaRepository staticMetaRepository, ILogger logger) : base(database, gateway, staticMetaRepository,
        logger)
    {
    }

    public PvpAmuletProvider Amulet => new(new PvpAmuletRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Pvp.Amulet, _gateway, _staticMetaRepository, _logger);
    public PvpHeroProvider Hero => new(new PvpHeroRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Pvp.Hero, _gateway, _staticMetaRepository, _logger);
    public PvpRankProvider Rank => new(new PvpRankRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Pvp.Rank, _gateway, _staticMetaRepository, _logger);
}

public class WvwProviders : ProviderBase
{
    internal WvwProviders(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway,
        StaticMetaRepository staticMetaRepository, ILogger logger) : base(database, gateway, staticMetaRepository,
        logger)
    {
    }

    public WvwAbilityProvider Ability => new(new WvwAbilityRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Ability, _gateway, _staticMetaRepository, _logger);
    public WvwObjectiveProvider Objective => new(new WvwObjectiveRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Objective, _gateway, _staticMetaRepository, _logger);
    public WvwRankProvider Rank => new(new WvwRankRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Rank, _gateway, _staticMetaRepository, _logger);
    public WvwUpgradeProvider Upgrade => new(new WvwUpgradeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Upgrade, _gateway, _staticMetaRepository, _logger);
}

public abstract class ProviderBase
{
    protected readonly Gw2ApiPersistenceDatabase _database;
    protected readonly Gw2ApiGateway _gateway;
    protected readonly StaticMetaRepository _staticMetaRepository;
    protected readonly ILogger _logger;

    internal ProviderBase(Gw2ApiPersistenceDatabase database, Gw2ApiGateway gateway, StaticMetaRepository staticMetaRepository, ILogger logger)
    {
        _database = database;
        _gateway = gateway;
        _staticMetaRepository = staticMetaRepository;
        _logger = logger;
    }
}