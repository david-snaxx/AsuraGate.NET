using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountHomeNodeRequest :
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountHomeNode;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
