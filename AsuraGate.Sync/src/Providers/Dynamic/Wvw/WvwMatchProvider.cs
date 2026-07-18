using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Wvw.V2;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.V2.Wvw;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Wvw;

public class WvwMatchProvider(WvwMatchRepository repository, WvwMatchRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
    : KeyedSnapshotProvider<WvwMatch, string, WvwMatchRepository, WvwMatchRequest>(repository, request, gateway, model => model.Id, logger);
