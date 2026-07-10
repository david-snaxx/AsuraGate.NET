using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Pvp;

public sealed class PvpStandingRequest :
    IGetsSingleNoId<PvpStanding>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.PvpStanding;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
