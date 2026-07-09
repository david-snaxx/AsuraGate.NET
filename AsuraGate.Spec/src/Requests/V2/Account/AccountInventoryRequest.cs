using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountInventoryRequest :
    IGetsSingle<AccountSharedInventoryItem, int>,
    IGetsBulk<AccountSharedInventoryItem, int>,
    IGetsAll<AccountSharedInventoryItem>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountInventory;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
