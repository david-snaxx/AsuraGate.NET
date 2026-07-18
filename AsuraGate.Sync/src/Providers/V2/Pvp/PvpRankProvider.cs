using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.Spec.Requests.V2.Pvp;
using AsuraGate.Persistence.Static.Repositories.V2.Pvp;

namespace AsuraGate.Sync.Providers.V2.Pvp;

public class PvpRankProvider(
    PvpRankRepository repository,
    PvpRankRequest request,
    Gw2ApiGateway gateway,
    StaticMetaRepository staticMetaRepository,
    ILogger? logger = null)
    : Provider<PvpRank, int, PvpRankRepository, PvpRankRequest>(repository, request, gateway, staticMetaRepository,
        logger);
