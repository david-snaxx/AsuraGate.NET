using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class SkinRequest :
    IGetsSingle<Skin, int>,
    IGetsBulk<Skin, int>,
    IGetsAll<Skin, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Skin;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
