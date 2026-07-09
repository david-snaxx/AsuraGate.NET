using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Commerce;

public class CommerceDeliveryRequest :
    IGetsSingleNoId<CommerceDelivery>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.CommerceDelivery;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
