using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Mount;

public sealed class MountTypeRequest :
    IGetsSingle<MountType, string>,
    IGetsBulk<MountType, string>,
    IGetsAll<MountType>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.MountType;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
