using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class RaceRequest :
    IGetsSingle<Race, string>,
    IGetsBulk<Race, string>,
    IGetsAll<Race>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Race;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
