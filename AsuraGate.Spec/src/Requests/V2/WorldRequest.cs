using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class WorldRequest :
    IGetsSingle<World, int>,
    IGetsBulk<World, int>,
    IGetsAll<World>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.World;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
