using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class WorldProvider : Provider<World, int, WorldRepository, WorldRequest>
{
    public WorldProvider(WorldRepository repository, WorldRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
