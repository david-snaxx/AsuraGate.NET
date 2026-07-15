using AsuraGate.Gateway;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.Spec.Requests.V2.Homestead;
using AsuraGate.Persistence.Static.Repositories.V2.Homestead;

namespace AsuraGate.Sync.Providers.V2.Homestead;

public class HomesteadDecorationCategoryProvider : Provider<HomesteadDecorationCategory, int, HomesteadDecorationCategoryRepository, HomesteadDecorationCategoryRequest>
{
    public HomesteadDecorationCategoryProvider(HomesteadDecorationCategoryRepository repository, HomesteadDecorationCategoryRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
        : base(repository, request, gateway, logger)
    {
    }
}
