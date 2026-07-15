using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.V2.Wvw;
using AsuraGate.Persistence.Static.Repositories.V2.Wvw;

namespace AsuraGate.Sync.Providers.V2.Wvw;

public class WvwObjectiveProvider : Provider<WvwObjective, string, WvwObjectiveRepository, WvwObjectiveRequest>
{
    public WvwObjectiveProvider(WvwObjectiveRepository repository, WvwObjectiveRequest request, Gw2ApiGateway gateway, StaticMetaRepository staticMetaRepository, ILogger? logger = null)
        : base(repository, request, gateway, staticMetaRepository, logger)
    {
    }
}
