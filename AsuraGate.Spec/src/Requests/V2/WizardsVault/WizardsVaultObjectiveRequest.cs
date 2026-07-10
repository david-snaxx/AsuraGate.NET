using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.WizardsVault;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.WizardsVault;

public sealed class WizardsVaultObjectiveRequest :
    IGetsSingle<WizardsVaultObjective, int>,
    IGetsBulk<WizardsVaultObjective, int>,
    IGetsAll<WizardsVaultObjective>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WizardsVaultObjective;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
