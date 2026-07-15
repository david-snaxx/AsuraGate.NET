using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class LegendProvider : Provider<Legend, string, LegendRepository, LegendRequest>
{
    public LegendProvider(LegendRepository repository, LegendRequest request, Gw2ApiGateway gateway, StaticMetaRepository staticMetaRepository, ILogger? logger = null)
        : base(repository, request, gateway, staticMetaRepository, logger)
    {
    }
}
