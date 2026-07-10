using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Commerce;

public sealed class CommercePriceRequest :
    IGetsSingle<CommerceTransaction, int>,
    IGetsBulk<CommerceTransaction, int>,
    IGetsAll<CommerceTransaction>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.CommercePrice;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
