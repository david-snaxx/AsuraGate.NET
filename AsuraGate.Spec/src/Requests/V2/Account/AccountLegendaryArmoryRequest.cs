using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountLegendaryArmoryRequest :
    IGetsAll<AccountLegendaryItem>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountLegendaryArmory;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
