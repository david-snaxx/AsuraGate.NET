using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountMaterialRequest :
    IGetsAll<AccountMaterial>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountMaterial;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
