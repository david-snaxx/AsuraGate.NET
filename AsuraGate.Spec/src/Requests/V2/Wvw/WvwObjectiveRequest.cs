using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public sealed class WvwObjectiveRequest :
    IGetsSingle<WvwObjective, string>,
    IGetsBulk<WvwObjective, string>,
    IGetsAll<WvwObjective, string>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwObjective;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}