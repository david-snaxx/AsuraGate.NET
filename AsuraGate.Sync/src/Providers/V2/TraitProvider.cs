using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class TraitProvider(
    TraitRepository repository,
    TraitRequest request,
    Gw2ApiGateway gateway,
    StaticMetaRepository staticMetaRepository,
    ILogger? logger = null)
    : Provider<Trait, int, TraitRepository, TraitRequest>(repository, request, gateway, staticMetaRepository, logger);
