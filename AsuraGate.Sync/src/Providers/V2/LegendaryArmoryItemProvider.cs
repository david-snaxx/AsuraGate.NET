using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class LegendaryArmoryItemProvider(
    LegendaryArmoryItemRepository repository,
    LegendaryArmoryRequest request,
    Gw2ApiGateway gateway,
    StaticMetaRepository staticMetaRepository,
    ILogger? logger = null)
    : Provider<LegendaryArmoryItem, int, LegendaryArmoryItemRepository, LegendaryArmoryRequest>(repository, request,
        gateway, staticMetaRepository, logger);
