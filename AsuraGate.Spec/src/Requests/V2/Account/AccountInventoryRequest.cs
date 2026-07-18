using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public sealed class AccountInventoryRequest :
    IGetsAll<AccountSharedInventoryItem, int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountInventory;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
