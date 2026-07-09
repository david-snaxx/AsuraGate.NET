using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class OutfitRequest :
    IGetsSingle<Outfit, int>,
    IGetsBulk<Outfit, int>,
    IGetsAll<Outfit>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Outfit;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
