using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class SkiffRequest :
    IGetsSingle<Skiff, int>,
    IGetsBulk<Skiff, int>,
    IGetsAll<Skiff>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Skiff;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
