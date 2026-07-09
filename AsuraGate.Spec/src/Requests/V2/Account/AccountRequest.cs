using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public sealed class AccountRequest :
    IGetsSingleNoId<Models.V2.Account>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Account;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
