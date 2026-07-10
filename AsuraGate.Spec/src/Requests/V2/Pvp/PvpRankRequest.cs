using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Pvp;

public sealed class PvpRankRequest :
    IGetsSingle<PvpRank, int>,
    IGetsBulk<PvpRank, int>,
    IGetsAll<PvpRank>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.PvpRank;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
