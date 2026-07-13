using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.V2.Wvw;
using AsuraGate.StaticCache.Repositories.V2.Wvw;

namespace AsuraGate.Sync.Providers.V2.Wvw;

public class WvwRankProvider : Provider<WvwRank, int, WvwRankRepository, WvwRankRequest>
{
    public WvwRankProvider(WvwRankRepository repository, WvwRankRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
