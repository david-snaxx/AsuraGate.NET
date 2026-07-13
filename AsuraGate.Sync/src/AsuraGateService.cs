using AsuraGate.Gateway;
using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests;
using AsuraGate.StaticCache;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync;

public class AsuraGateService : IAsyncDisposable
{
    public Gw2ApiGateway Gw2ApiGateway { get; }
    public Gw2ApiNavigator Gw2ApiNavigator { get; }
    public Gw2ApiStaticCacheDatabase Gw2ApiStaticCacheDatabase { get; }
    public ProviderLink Api { get; }
    private readonly ILogger _logger;

    public AsuraGateService(string gw2ApiKey, string staticCacheDatabasePath, string defaultLocalization, string defaultSchemaVersion, ILogger? logger = null)
    {
        Gw2ApiGateway = new Gw2ApiGateway(
            gw2ApiKey,
            defaultLocalization?.ToString() ?? Gw2ApiLocalization.English,
            defaultSchemaVersion?.ToString() ?? Gw2ApiSchemaVersion.Latest,
            _logger = logger ?? NullLogger<Gw2ApiGateway>.Instance);
        Gw2ApiNavigator = Gw2ApiNavigator.Instance;
        Gw2ApiStaticCacheDatabase = new Gw2ApiStaticCacheDatabase(staticCacheDatabasePath);
        Gw2ApiStaticCacheDatabase.Initialize().Wait();
        Api = new ProviderLink(Gw2ApiStaticCacheDatabase, Gw2ApiGateway);
    }
    
    public async ValueTask DisposeAsync()
    {
        await Gw2ApiStaticCacheDatabase.DisposeAsync();
    }
    
    public static async Task<AsuraGateService> CreateAsync(string gw2ApiKey, string staticCacheDatabasePath, string defaultLocalization, string defaultSchemaVersion, ILogger? logger = null)
    {
        var service = new AsuraGateService(gw2ApiKey, staticCacheDatabasePath, defaultLocalization, defaultSchemaVersion, logger);
        await service.Gw2ApiStaticCacheDatabase.Initialize();
        return service;
    }
}