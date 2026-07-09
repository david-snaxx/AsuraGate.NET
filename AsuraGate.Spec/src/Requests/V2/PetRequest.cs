using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class PetRequest :
    IGetsSingle<Pet, int>,
    IGetsBulk<Pet, int>,
    IGetsAll<Pet>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Pet;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
