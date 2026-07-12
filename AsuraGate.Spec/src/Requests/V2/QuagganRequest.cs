using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class QuagganRequest :
    IGetsSingle<Quaggan, string>,
    IGetsBulk<Quaggan, string>,
    IGetsAll<Quaggan, string>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Quaggan;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
