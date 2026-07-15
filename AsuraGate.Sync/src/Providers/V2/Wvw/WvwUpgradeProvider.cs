using AsuraGate.Gateway;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.V2.Wvw;
using AsuraGate.Persistence.Static.Repositories.V2.Wvw;

namespace AsuraGate.Sync.Providers.V2.Wvw;

public class WvwUpgradeProvider : Provider<WvwUpgrade, int, WvwUpgradeRepository, WvwUpgradeRequest>
{
    public WvwUpgradeProvider(WvwUpgradeRepository repository, WvwUpgradeRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
        : base(repository, request, gateway, logger)
    {
    }
}
