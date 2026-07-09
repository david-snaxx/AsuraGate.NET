using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class MiniRequest :
    IGetsSingle<Mini, int>,
    IGetsBulk<Mini, int>,
    IGetsAll<Mini>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Mini;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
