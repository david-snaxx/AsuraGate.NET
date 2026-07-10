using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class MapRequest :
    IGetsSingle<GameMap, int>,
    IGetsBulk<GameMap, int>,
    IGetsAll<GameMap>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Map;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
