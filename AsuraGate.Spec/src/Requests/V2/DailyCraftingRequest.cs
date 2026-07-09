using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class DailyCraftingRequest :
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.DailyCrafting;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
