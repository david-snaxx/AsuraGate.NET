using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Emblem;

public sealed class EmblemForegroundRequest :
    IGetsSingle<EmblemComponent, int>,
    IGetsBulk<EmblemComponent, int>,
    IGetsAll<EmblemComponent>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.EmblemForeground;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
