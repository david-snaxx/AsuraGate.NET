using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.Spec.Requests.V2.Mount;
using AsuraGate.Persistence.Static.Repositories.V2.Mount;

namespace AsuraGate.Sync.Providers.V2.Mount;

public class MountSkinProvider : Provider<MountSkin, int, MountSkinRepository, MountSkinRequest>
{
    public MountSkinProvider(MountSkinRepository repository, MountSkinRequest request, Gw2ApiGateway gateway, StaticMetaRepository staticMetaRepository, ILogger? logger = null)
        : base(repository, request, gateway, staticMetaRepository, logger)
    {
    }
}
