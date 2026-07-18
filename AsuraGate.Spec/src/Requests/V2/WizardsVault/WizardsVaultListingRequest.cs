using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.WizardsVault;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.WizardsVault;

public sealed class WizardsVaultListingRequest :
    IGetsSingle<WizardsVaultListing, string>,
    IGetsBulk<WizardsVaultListing, string>,
    IGetsAll<WizardsVaultListing, string>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WizardsVaultListing;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
