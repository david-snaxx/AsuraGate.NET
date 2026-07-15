using AsuraGate.Gateway;
using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests;
using AsuraGate.Persistence;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync;

public class AsuraGateService : IAsyncDisposable
{
    public Gw2ApiGateway Gw2ApiGateway { get; }
    public Gw2ApiNavigator Gw2ApiNavigator { get; }
    public Gw2ApiPersistenceDatabase Gw2ApiPersistenceDatabase { get; }
    public Gw2ApiDynamicDatabase Gw2ApiDynamicDatabase { get; }
    public ProviderLink Api { get; }
    private readonly ILogger _logger;

    public AsuraGateService(string gw2ApiKey, string staticDatabasePath, string dynamicDatabasePath, string defaultLocalization, string defaultSchemaVersion, ILogger? logger = null)
    {
        Gw2ApiGateway = new Gw2ApiGateway(
            gw2ApiKey,
            defaultLocalization?.ToString() ?? Gw2ApiLocalization.English,
            defaultSchemaVersion?.ToString() ?? Gw2ApiSchemaVersion.Latest,
            _logger = logger ?? NullLogger<Gw2ApiGateway>.Instance);
        Gw2ApiNavigator = Gw2ApiNavigator.Instance;
        Gw2ApiPersistenceDatabase = new Gw2ApiPersistenceDatabase(staticDatabasePath);
        Gw2ApiPersistenceDatabase.Initialize().Wait();
        Gw2ApiDynamicDatabase = new Gw2ApiDynamicDatabase(dynamicDatabasePath);
        Gw2ApiDynamicDatabase.Initialize().Wait();
        Api = new ProviderLink(Gw2ApiPersistenceDatabase, Gw2ApiGateway, _logger);
    }

    public async ValueTask DisposeAsync()
    {
        await Gw2ApiPersistenceDatabase.DisposeAsync();
        await Gw2ApiDynamicDatabase.DisposeAsync();
    }

    public static async Task<AsuraGateService> CreateAsync(string gw2ApiKey, string staticDatabasePath, string dynamicDatabasePath, string defaultLocalization, string defaultSchemaVersion, ILogger? logger = null)
    {
        var service = new AsuraGateService(gw2ApiKey, staticDatabasePath, dynamicDatabasePath, defaultLocalization, defaultSchemaVersion, logger);
        await service.Gw2ApiPersistenceDatabase.Initialize();
        await service.Gw2ApiDynamicDatabase.Initialize();
        return service;
    }
}
