using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class SpecializationRequest :
    IGetsSingle<Specialization, int>,
    IGetsBulk<Specialization, int>,
    IGetsAll<Specialization>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Specialization;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
