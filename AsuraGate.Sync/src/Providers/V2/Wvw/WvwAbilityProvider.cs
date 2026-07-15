using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.V2.Wvw;
using AsuraGate.Persistence.Static.Repositories.V2.Wvw;

namespace AsuraGate.Sync.Providers.V2.Wvw;

public class WvwAbilityProvider : Provider<WvwAbility, int, WvwAbilityRepository, WvwAbilityRequest>
{
    public WvwAbilityProvider(WvwAbilityRepository repository, WvwAbilityRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
