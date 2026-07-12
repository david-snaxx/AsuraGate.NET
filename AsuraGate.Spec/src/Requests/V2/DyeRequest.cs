using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class DyeRequest :
    IGetsSingle<Dye, int>,
    IGetsBulk<Dye, int>,
    IGetsAll<Dye, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Dye;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
