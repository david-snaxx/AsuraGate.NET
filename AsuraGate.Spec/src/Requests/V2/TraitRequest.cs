using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class TraitRequest :
    IGetsSingle<Trait, int>,
    IGetsBulk<Trait, int>,
    IGetsAll<Trait>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Trait;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
