using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class BuildRequest :
    IGetsSingleNoId<Build>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Build;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
