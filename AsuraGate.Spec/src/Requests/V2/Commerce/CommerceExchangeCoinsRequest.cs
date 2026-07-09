using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Commerce;

public sealed class CommerceExchangeCoinsRequest :
    IGw2ApiRequest<CommerceExchange>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.CommerceExchangeCoin;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}