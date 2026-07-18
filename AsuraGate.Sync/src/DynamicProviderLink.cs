using AsuraGate.Gateway;
using AsuraGate.Persistence;
using AsuraGate.Persistence.Dynamic.Repositories.Account.V2;
using AsuraGate.Persistence.Dynamic.Repositories.Character.V2;
using AsuraGate.Persistence.Dynamic.Repositories.Wvw.V2;
using AsuraGate.Spec.Requests;
using AsuraGate.Sync.Providers.Dynamic.Account;
using AsuraGate.Sync.Providers.Dynamic.Character;
using AsuraGate.Sync.Providers.Dynamic.Wvw;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync;

public class DynamicProviderLink : DynamicProviderBase
{
    internal DynamicProviderLink(Gw2ApiDynamicDatabase database, Gw2ApiGateway apiGateway, ILogger logger)
        : base(database, apiGateway, logger)
    {
    }

    public DynamicAccountProviders Account => new(_database, _gateway, _logger);
    public DynamicCharacterProviders Character => new(_database, _gateway, _logger);
    public DynamicWvwProviders Wvw => new(_database, _gateway, _logger);
}

public class DynamicAccountProviders : DynamicProviderBase
{
    internal DynamicAccountProviders(Gw2ApiDynamicDatabase database, Gw2ApiGateway apiGateway, ILogger logger)
        : base(database, apiGateway, logger)
    {
    }

    // single objects, no id
    public AccountLuckProvider Luck => new(new AccountLuckRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Luck, _gateway, _logger);
    public AccountMasteryPointsProvider MasteryPoints => new(new AccountMasteryPointsRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.MasteryPoints, _gateway, _logger);
    public AccountWizardsVaultDailyProvider WizardsVaultDaily => new(new AccountWizardsVaultDailyRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.WizardsVaultDaily, _gateway, _logger);
    public AccountWizardsVaultSpecialProvider WizardsVaultSpecial => new(new AccountWizardsVaultSpecialRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.WizardsVaultSpecial, _gateway, _logger);
    public AccountWizardsVaultWeeklyProvider WizardsVaultWeekly => new(new AccountWizardsVaultWeeklyRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.WizardsVaultWeekly, _gateway, _logger);
    public AccountWvwProvider Wvw => new(new AccountWvwRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Wvw, _gateway, _logger);

    // full collections via GetAll
    public AccountAchievementProvider Achievement => new(new AccountAchievementRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Achievements, _gateway, _logger);
    public AccountBankProvider Bank => new(new AccountBankRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Bank, _gateway, _logger);
    public AccountBuildStorageProvider BuildStorage => new(new AccountBuildStorageRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.BuildStorage, _gateway, _logger);
    public AccountFinisherProvider Finisher => new(new AccountFinisherRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Finisher, _gateway, _logger);
    public AccountHomesteadDecorationProvider HomesteadDecoration => new(new AccountHomesteadDecorationRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.HomesteadDecoration, _gateway, _logger);
    public AccountInventoryProvider Inventory => new(new AccountInventoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Inventory, _gateway, _logger);
    public AccountLegendaryArmoryProvider LegendaryArmory => new(new AccountLegendaryArmoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.LegendaryArmory, _gateway, _logger);
    public AccountMasteryProvider Mastery => new(new AccountMasteryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Mastery, _gateway, _logger);
    public AccountMaterialProvider Material => new(new AccountMaterialRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Material, _gateway, _logger);
    public AccountProgressionProvider Progression => new(new AccountProgressionRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Progression, _gateway, _logger);
    public AccountWalletProvider Wallet => new(new AccountWalletRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Wallet, _gateway, _logger);

    // raw id lists via GetAllIds
    public AccountDyeProvider Dye => new(new AccountDyeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Dye, _gateway, _logger);
    public AccountEmoteProvider Emote => new(new AccountEmoteRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Emote, _gateway, _logger);
    public AccountGliderProvider Glider => new(new AccountGliderRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Glider, _gateway, _logger);
    public AccountHomeCatProvider HomeCat => new(new AccountHomeCatRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.HomeCat, _gateway, _logger);
    public AccountHomeNodeProvider HomeNode => new(new AccountHomeNodeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.HomeNode, _gateway, _logger);
    public AccountHomesteadGlyphProvider HomesteadGlyph => new(new AccountHomesteadGlyphRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.HomesteadGlyph, _gateway, _logger);
    public AccountJadeBotProvider JadeBot => new(new AccountJadeBotRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.JadeBot, _gateway, _logger);
    public AccountMailCarrierProvider MailCarrier => new(new AccountMailCarrierRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.MailCarrier, _gateway, _logger);
    public AccountMiniProvider Mini => new(new AccountMiniRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Mini, _gateway, _logger);
    public AccountMountSkinProvider MountSkin => new(new AccountMountSkinRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.MountSkin, _gateway, _logger);
    public AccountMountTypeProvider MountType => new(new AccountMountTypeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.MountType, _gateway, _logger);
    public AccountNoveltyProvider Novelty => new(new AccountNoveltyRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Novelty, _gateway, _logger);
    public AccountOutfitProvider Outfit => new(new AccountOutfitRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Outfit, _gateway, _logger);
    public AccountPvpHeroProvider PvpHero => new(new AccountPvpHeroRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.PvpHero, _gateway, _logger);
    public AccountRecipeProvider Recipe => new(new AccountRecipeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Recipe, _gateway, _logger);
    public AccountSkiffProvider Skiff => new(new AccountSkiffRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Skiff, _gateway, _logger);
    public AccountSkinProvider Skin => new(new AccountSkinRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Skin, _gateway, _logger);
    public AccountTitleProvider Title => new(new AccountTitleRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Account.Title, _gateway, _logger);
}

public class DynamicCharacterProviders : DynamicProviderBase
{
    internal DynamicCharacterProviders(Gw2ApiDynamicDatabase database, Gw2ApiGateway apiGateway, ILogger logger)
        : base(database, apiGateway, logger)
    {
    }

    // single objects scoped to one character at construction time - key = characterName
    public CharacterBackstoryProvider Backstory(string characterName) =>
        new(new CharacterBackstoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Backstory(characterName), _gateway, characterName, _logger);

    public CharacterCoreProvider Core(string characterName) =>
        new(new CharacterCoreRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.CharacterCore(characterName), _gateway, characterName, _logger);

    public CharacterCraftingProvider Crafting(string characterName) =>
        new(new CharacterCraftingRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Crafting(characterName), _gateway, characterName, _logger);

    public CharacterEquipmentProvider Equipment(string characterName) =>
        new(new CharacterEquipmentRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Equipment(characterName), _gateway, characterName, _logger);

    public CharacterInventoryProvider Inventory(string characterName) =>
        new(new CharacterInventoryRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Inventory(characterName), _gateway, characterName, _logger);

    public CharacterSabProvider Sab(string characterName) =>
        new(new CharacterSabRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Sab(characterName), _gateway, characterName, _logger);

    public CharacterSkillsProvider Skills(string characterName) =>
        new(new CharacterSkillsRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Skills(characterName), _gateway, characterName, _logger);

    public CharacterSpecializationsProvider Specializations(string characterName) =>
        new(new CharacterSpecializationsRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Specializations(characterName), _gateway, characterName, _logger);

    public CharacterTrainingProvider Training(string characterName) =>
        new(new CharacterTrainingRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Training(characterName), _gateway, characterName, _logger);

    // keyed collections via GetAll
    public CharacterBuildTabProvider BuildTab(string characterName) =>
        new(new CharacterBuildTabRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.BuildTab(characterName), _gateway, characterName, _logger);

    public CharacterEquipmentTabProvider EquipmentTab(string characterName) =>
        new(new CharacterEquipmentTabRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.EquipmentTab(characterName), _gateway, characterName, _logger);

    // keyed id-lists via GetAllIds
    public CharacterHeroPointProvider HeroPoint(string characterName) =>
        new(new CharacterHeroPointRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.HeroPoints(characterName), _gateway, characterName, _logger);

    public CharacterQuestProvider Quest(string characterName) =>
        new(new CharacterQuestRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Quest(characterName), _gateway, characterName, _logger);

    public CharacterRecipeProvider Recipe(string characterName) =>
        new(new CharacterRecipeRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.Characters.Recipes(characterName), _gateway, characterName, _logger);
}

public class DynamicWvwProviders : DynamicProviderBase
{
    internal DynamicWvwProviders(Gw2ApiDynamicDatabase database, Gw2ApiGateway apiGateway, ILogger logger)
        : base(database, apiGateway, logger)
    {
    }

    public WvwMatchProvider Match => new(new WvwMatchRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.Match, _gateway, _logger);
    public WvwMatchWorldOverviewProvider MatchWorldOverview => new(new WvwMatchWorldOverviewRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.MatchWorldOverview, _gateway, _logger);
    public WvwMatchWorldScoresProvider MatchWorldScores => new(new WvwMatchWorldScoresRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.MatchWorldScores, _gateway, _logger);
    public WvwMatchWorldStatsProvider MatchWorldStats => new(new WvwMatchWorldStatsRepository(_database), Gw2ApiNavigator.Instance.Api.VersionTwo.WvW.MatchWorldStats, _gateway, _logger);
}

public abstract class DynamicProviderBase
{
    protected readonly Gw2ApiDynamicDatabase _database;
    protected readonly Gw2ApiGateway _gateway;
    protected readonly ILogger _logger;

    internal DynamicProviderBase(Gw2ApiDynamicDatabase database, Gw2ApiGateway gateway, ILogger logger)
    {
        _database = database;
        _gateway = gateway;
        _logger = logger;
    }
}
