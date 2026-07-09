using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class FinisherRequest :
    IGetsSingle<Finisher, int>,
    IGetsBulk<Finisher, int>,
    IGetsAll<Finisher>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Finisher;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
