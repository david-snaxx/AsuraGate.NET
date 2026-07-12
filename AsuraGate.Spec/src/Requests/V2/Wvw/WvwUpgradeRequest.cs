using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public class WvwUpgradeRequest :
    IGetsSingle<WvwUpgrade, int>,
    IGetsBulk<WvwUpgrade, int>,
    IGetsAll<WvwUpgrade, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwUpgrade;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
