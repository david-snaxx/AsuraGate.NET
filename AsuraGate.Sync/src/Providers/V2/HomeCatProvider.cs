using AsuraGate.Gateway;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2.Home;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class HomeCatProvider : Provider<HomeCat, int, HomeCatRepository, HomeCatRequest>
{
    public HomeCatProvider(HomeCatRepository repository, HomeCatRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
        : base(repository, request, gateway, logger)
    {
    }
}
