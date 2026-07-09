using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class MailCarrierRequest :
    IGetsSingle<MailCarrier, int>,
    IGetsBulk<MailCarrier, int>,
    IGetsAll<MailCarrier>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.MailCarrier;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
