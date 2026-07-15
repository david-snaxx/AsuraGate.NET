using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2.Emblem;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class EmblemBackgroundProvider : Provider<EmblemComponent, int, EmblemBackgroundRepository, EmblemBackgroundRequest>
{
    public EmblemBackgroundProvider(EmblemBackgroundRepository repository, EmblemBackgroundRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
