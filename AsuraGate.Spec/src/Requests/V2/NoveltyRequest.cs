using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class NoveltyRequest :
    IGetsSingle<Novelty, int>,
    IGetsBulk<Novelty, int>,
    IGetsAll<Novelty>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Novelty;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
