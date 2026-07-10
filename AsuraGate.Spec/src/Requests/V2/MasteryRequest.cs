using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class MasteryRequest :
    IGetsSingle<Mastery, int>,
    IGetsBulk<Mastery, int>,
    IGetsAll<Mastery>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Mastery;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
