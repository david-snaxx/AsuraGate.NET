using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountFinisherRequest :
    IGetsSingle<AccountFinisher, int>,
    IGetsBulk<AccountFinisher, int>,
    IGetsAll<AccountFinisher>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountFinisher;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
