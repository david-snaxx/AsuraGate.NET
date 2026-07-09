using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountHomesteadDecorationRequest :
    IGetsSingle<AccountHomesteadDecoration, int>,
    IGetsBulk<AccountHomesteadDecoration, int>,
    IGetsAll<AccountHomesteadDecoration>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountHomesteadDecoration;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
