using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Wvw.V2;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.V2.Wvw;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Wvw;

// fetched by world id (int) but stored keyed by the match id the world belongs to
public class WvwMatchWorldOverviewProvider(
    WvwMatchWorldOverviewRepository repository,
    WvwMatchWorldOverviewRequest request,
    Gw2ApiGateway gateway,
    ILogger? logger = null)
    : KeyedSnapshotProvider<WvwMatchWorldOverview, int, WvwMatchWorldOverviewRepository, WvwMatchWorldOverviewRequest>(
        repository, request, gateway, model => model.Id, logger);
