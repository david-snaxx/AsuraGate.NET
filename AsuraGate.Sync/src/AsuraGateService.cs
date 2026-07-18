using AsuraGate.Gateway;
using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.Spec.Requests.V2.Account;
using AsuraGate.Persistence;
using AsuraGate.Persistence.Static.Mappers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Account = AsuraGate.Spec.Models.V2.Account.Account;

namespace AsuraGate.Sync;

public class AsuraGateService : IAsyncDisposable
{
    private const string StaticDatabaseFileName = "gw2-static-cache.db";

    public Gw2ApiGateway Gw2ApiGateway { get; }
    public Gw2ApiNavigator Gw2ApiNavigator { get; }
    public Gw2ApiPersistenceDatabase Gw2ApiPersistenceDatabase { get; }
    public Gw2ApiDynamicDatabase Gw2ApiDynamicDatabase { get; }
    public ProviderLink Api { get; }
    private readonly ILogger _logger;

    private AsuraGateService(Gw2ApiGateway gateway, string staticDatabasePath, string dynamicDatabasePath, ILogger logger)
    {
        Gw2ApiGateway = gateway;
        _logger = logger;
        MapperUtils.Configure(logger);
        Gw2ApiNavigator = Gw2ApiNavigator.Instance;
        Gw2ApiPersistenceDatabase = new Gw2ApiPersistenceDatabase(staticDatabasePath);
        Gw2ApiDynamicDatabase = new Gw2ApiDynamicDatabase(dynamicDatabasePath);
        Api = new ProviderLink(Gw2ApiPersistenceDatabase, Gw2ApiGateway, _logger);
    }

    public async ValueTask DisposeAsync()
    {
        await Gw2ApiPersistenceDatabase.DisposeAsync();
        await Gw2ApiDynamicDatabase.DisposeAsync();
    }

    /// <summary>
    /// Resolves the GW2 account tied to <paramref name="gw2ApiKey"/> and creates a fully-initialized
    /// service backed by a static cache (a fixed-name file inside <paramref name="staticDatabaseDirectory"/>)
    /// and an account-scoped dynamic database file (named after the resolved account id) inside
    /// <paramref name="dynamicDatabaseDirectory"/>.
    /// </summary>
    public static async Task<AsuraGateService> CreateAsync(
        string gw2ApiKey,
        string staticDatabaseDirectory,
        string dynamicDatabaseDirectory,
        string? defaultLocalization = null,
        string? defaultSchemaVersion = null,
        ILogger? logger = null,
        CancellationToken cancellationToken = default)
    {
        ILogger resolvedLogger = logger ?? NullLogger<Gw2ApiGateway>.Instance;
        Gw2ApiGateway gateway = new(
            gw2ApiKey,
            defaultLocalization ?? Gw2ApiLocalization.English,
            defaultSchemaVersion ?? Gw2ApiSchemaVersion.Latest,
            resolvedLogger);

        Account account = await gateway.FetchAsync(new AccountRequest().GetObject<Account, string>(), cancellationToken)
            ?? throw new InvalidOperationException("Could not resolve the GW2 account for the supplied API key.");

        Directory.CreateDirectory(staticDatabaseDirectory);
        string staticDatabasePath = Path.Combine(staticDatabaseDirectory, StaticDatabaseFileName);

        Directory.CreateDirectory(dynamicDatabaseDirectory);
        string dynamicDatabasePath = Path.Combine(dynamicDatabaseDirectory, $"{account.Id}.db");

        var service = new AsuraGateService(gateway, staticDatabasePath, dynamicDatabasePath, resolvedLogger);
        await service.Gw2ApiPersistenceDatabase.Initialize();
        await service.Gw2ApiDynamicDatabase.Initialize();
        return service;
    }
}
