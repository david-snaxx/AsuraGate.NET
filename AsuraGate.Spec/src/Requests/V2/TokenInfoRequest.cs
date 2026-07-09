using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class TokenInfoRequest :
    IGetsSingleNoId<TokenInfo>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.TokenInfo;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
