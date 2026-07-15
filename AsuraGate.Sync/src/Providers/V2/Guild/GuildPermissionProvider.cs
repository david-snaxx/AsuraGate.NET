using AsuraGate.Gateway;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.Spec.Requests.V2.Guild;
using AsuraGate.Persistence.Static.Repositories.V2.Guild;

namespace AsuraGate.Sync.Providers.V2.Guild;

public class GuildPermissionProvider : Provider<GuildPermission, string, GuildPermissionRepository, GuildPermissionRequest>
{
    public GuildPermissionProvider(GuildPermissionRepository repository, GuildPermissionRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
        : base(repository, request, gateway, logger)
    {
    }
}
