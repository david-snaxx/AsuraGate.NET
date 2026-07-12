using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class JadeBotRequest :
    IGetsSingle<JadeBot, int>,
    IGetsBulk<JadeBot, int>,
    IGetsAll<JadeBot, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.JadeBot;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
