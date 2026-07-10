using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Homestead;

public sealed class HomesteadDecorationRequest :
    IGetsSingle<HomesteadDecoration, int>,
    IGetsBulk<HomesteadDecoration, int>,
    IGetsAll<HomesteadDecoration>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.HomesteadDecoration;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
