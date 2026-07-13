using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.Spec.Requests.V2.Mount;
using AsuraGate.StaticCache.Repositories.V2.Mount;

namespace AsuraGate.Sync.Providers.V2.Mount;

public class MountTypeProvider : Provider<MountType, string, MountTypeRepository, MountTypeRequest>
{
    public MountTypeProvider(MountTypeRepository repository, MountTypeRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
