using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.WizardsVault;

public sealed class WizardsVaultRequest :
    IGetsSingleNoId<WizardsVaultSeason>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WizardsVault;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
