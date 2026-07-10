using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public sealed class WvwAbilityRequest :
    IGetsSingle<WvwAbility, int>,
    IGetsBulk<WvwAbility, int>,
    IGetsAll<WvwAbility>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwAbility;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
