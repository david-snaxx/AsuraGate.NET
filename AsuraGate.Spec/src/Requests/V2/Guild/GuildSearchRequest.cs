using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Guild;

public class GuildSearchRequest :
    IGw2ApiRequest<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.GuildSearch;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
