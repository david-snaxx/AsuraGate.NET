using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public sealed class WvwEuGuildsRequest :
    IGetsSingleNoId<IDictionary<string, string>>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwGuildEu;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
