using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Home;

public sealed class HomeNodeRequest :
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.HomeNode;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
