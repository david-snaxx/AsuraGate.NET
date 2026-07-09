using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public sealed class WvwMatchWorldStatsRequest :
    IGetsSingle<WvwMatchWorldStats, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwMatchStat;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
