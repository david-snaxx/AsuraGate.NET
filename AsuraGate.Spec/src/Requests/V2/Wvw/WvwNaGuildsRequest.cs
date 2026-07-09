using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public class WvwNaGuildsRequest :
    IGetsSingleNoId<IDictionary<string, string>>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwGuildNa;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
