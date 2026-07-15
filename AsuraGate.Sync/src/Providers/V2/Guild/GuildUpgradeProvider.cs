using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.Spec.Requests.V2.Guild;
using AsuraGate.Persistence.Static.Repositories.V2.Guild;

namespace AsuraGate.Sync.Providers.V2.Guild;

public class GuildUpgradeProvider : Provider<GuildUpgrade, int, GuildUpgradeRepository, GuildUpgradesRequest>
{
    public GuildUpgradeProvider(GuildUpgradeRepository repository, GuildUpgradesRequest request, Gw2ApiGateway gateway, StaticMetaRepository staticMetaRepository, ILogger? logger = null)
        : base(repository, request, gateway, staticMetaRepository, logger)
    {
    }
}
