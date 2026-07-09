using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public class WvwMatchRequest :
    IGetsSingle<WvwMatch, string>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwMatch;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
