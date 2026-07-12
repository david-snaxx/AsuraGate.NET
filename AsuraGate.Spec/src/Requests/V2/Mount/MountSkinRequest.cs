using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Mount;

public sealed class MountSkinRequest :
    IGetsSingle<MountSkin, int>,
    IGetsBulk<MountSkin, int>,
    IGetsAll<MountSkin, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.MountSkin;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
