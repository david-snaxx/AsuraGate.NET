using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.Spec.Requests.V2.Pvp;
using AsuraGate.StaticCache.Repositories.V2.Pvp;

namespace AsuraGate.Sync.Providers.V2.Pvp;

public class PvpAmuletProvider : Provider<PvpAmulet, int, PvpAmuletRepository, PvpAmuletRequest>
{
    public PvpAmuletProvider(PvpAmuletRepository repository, PvpAmuletRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
