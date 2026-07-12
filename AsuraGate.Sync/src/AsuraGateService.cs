using AsuraGate.Gateway;
using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests;
using AsuraGate.StaticCache;

namespace AsuraGate.Sync;

public class AsuraGateService : IAsyncDisposable
{
    public Gw2ApiGateway Gw2ApiGateway { get; }
    public Gw2ApiNavigator Gw2ApiNavigator { get; }
    public Gw2ApiStaticCacheDatabase Gw2ApiStaticCacheDatabase { get; }

    public AsuraGateService(string gw2ApiKey, string staticCacheDatabasePath, string defaultLocalization, string defaultSchemaVersion)
    {
        Gw2ApiGateway = new Gw2ApiGateway(
            gw2ApiKey,
            defaultLocalization?.ToString() ?? Gw2ApiLocalization.English,
            defaultSchemaVersion?.ToString() ?? Gw2ApiSchemaVersion.Latest);
        Gw2ApiNavigator = Gw2ApiNavigator.Instance;
        Gw2ApiStaticCacheDatabase = new Gw2ApiStaticCacheDatabase(staticCacheDatabasePath);
        Gw2ApiStaticCacheDatabase.Initialize().Wait();
    }
    
    public async ValueTask DisposeAsync()
    {
        await Gw2ApiStaticCacheDatabase.DisposeAsync();
    }
}