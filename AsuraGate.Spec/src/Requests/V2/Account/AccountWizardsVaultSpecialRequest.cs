using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountWizardsVaultSpecialRequest :
    IGetsSingleNoId<AccountWizardsVaultSpecial>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountWizardsVaultSpecial;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
