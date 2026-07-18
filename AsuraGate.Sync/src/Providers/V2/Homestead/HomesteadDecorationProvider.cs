using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.Spec.Requests.V2.Homestead;
using AsuraGate.Persistence.Static.Repositories.V2.Homestead;

namespace AsuraGate.Sync.Providers.V2.Homestead;

public class HomesteadDecorationProvider(
    HomesteadDecorationRepository repository,
    HomesteadDecorationRequest request,
    Gw2ApiGateway gateway,
    StaticMetaRepository staticMetaRepository,
    ILogger? logger = null)
    : Provider<HomesteadDecoration, int, HomesteadDecorationRepository, HomesteadDecorationRequest>(repository, request,
        gateway, staticMetaRepository, logger);
