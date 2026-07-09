using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountGliderRequest :
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountGlider;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
