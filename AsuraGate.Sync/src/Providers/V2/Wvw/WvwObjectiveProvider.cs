using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.V2.Wvw;
using AsuraGate.StaticCache.Repositories.V2.Wvw;

namespace AsuraGate.Sync.Providers.V2.Wvw;

public class WvwObjectiveProvider : Provider<WvwObjective, string, WvwObjectiveRepository, WvwObjectiveRequest>
{
    public WvwObjectiveProvider(WvwObjectiveRepository repository, WvwObjectiveRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
