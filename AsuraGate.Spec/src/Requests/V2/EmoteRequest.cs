using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class EmoteRequest :
    IGetsSingle<Emote, int>,
    IGetsBulk<Emote, int>,
    IGetsAll<Emote>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Emote;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
