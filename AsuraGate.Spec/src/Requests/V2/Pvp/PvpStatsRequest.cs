using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Pvp;

public sealed class PvpStatsRequest :
    IGetsSingleNoId<PvpStats>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.PvpStat;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
