using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.Spec.Requests.V2.Pvp;
using AsuraGate.Persistence.Static.Repositories.V2.Pvp;

namespace AsuraGate.Sync.Providers.V2.Pvp;

public class PvpRankProvider : Provider<PvpRank, int, PvpRankRepository, PvpRankRequest>
{
    public PvpRankProvider(PvpRankRepository repository, PvpRankRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
