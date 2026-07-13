using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.StaticCache.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class LegendProvider : Provider<Legend, string, LegendRepository, LegendRequest>
{
    public LegendProvider(LegendRepository repository, LegendRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
