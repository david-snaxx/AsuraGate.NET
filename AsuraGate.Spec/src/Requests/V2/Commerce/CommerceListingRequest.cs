using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Commerce;

public sealed class CommerceListingRequest :
    IGetsSingle<CommerceListing, int>,
    IGetsBulk<CommerceListing, int>,
    IGetsAll<CommerceListing, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.CommerceListing;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
