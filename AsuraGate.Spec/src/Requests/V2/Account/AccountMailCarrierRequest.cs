using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public sealed class AccountMailCarrierRequest :
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountMailCarrier;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
