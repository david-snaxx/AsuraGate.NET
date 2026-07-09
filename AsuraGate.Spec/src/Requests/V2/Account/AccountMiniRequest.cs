using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountMiniRequest :
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountMini;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
