using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public class WvwObjectiveRequest :
    IGetsSingle<WvwObjective, string>,
    IGetsBulk<WvwObjective, string>,
    IGetsAll<WvwObjective>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwObjective;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}