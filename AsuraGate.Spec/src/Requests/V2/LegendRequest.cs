using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class LegendRequest :
    IGetsSingle<Legend, string>,
    IGetsBulk<Legend, string>,
    IGetsAll<Legend>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Legend;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
