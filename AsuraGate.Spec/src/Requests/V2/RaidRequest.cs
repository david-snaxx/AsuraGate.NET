using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class RaidRequest :
    IGetsSingle<Raid, string>,
    IGetsBulk<Raid, string>,
    IGetsAll<Raid>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Raid;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
