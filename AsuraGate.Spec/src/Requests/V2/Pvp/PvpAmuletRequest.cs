using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Pvp;

public class PvpAmuletRequest :
    IGetsSingle<PvpAmulet, int>,
    IGetsBulk<PvpAmulet, int>,
    IGetsAll<PvpAmulet>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.PvpAmulet;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
