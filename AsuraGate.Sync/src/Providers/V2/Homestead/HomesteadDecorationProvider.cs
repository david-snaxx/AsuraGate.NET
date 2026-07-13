using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.Spec.Requests.V2.Homestead;
using AsuraGate.StaticCache.Repositories.V2.Homestead;

namespace AsuraGate.Sync.Providers.V2.Homestead;

public class HomesteadDecorationProvider : Provider<HomesteadDecoration, int, HomesteadDecorationRepository, HomesteadDecorationRequest>
{
    public HomesteadDecorationProvider(HomesteadDecorationRepository repository, HomesteadDecorationRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
