using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class ContinentRequest :
    IGetsSingle<Continent, int>,
    IGetsBulk<Continent, int>,
    IGetsAll<Continent>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Continent;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
