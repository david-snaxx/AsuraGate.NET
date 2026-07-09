using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public class WvwRankRequest :
    IGetsSingle<WvwRank, int>,
    IGetsBulk<WvwRank, int>,
    IGetsAll<WvwRank>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwRank;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}