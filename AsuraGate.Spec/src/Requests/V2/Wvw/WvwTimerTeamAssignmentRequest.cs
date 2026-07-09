using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

public class WvwTimerTeamAssignmentRequest :
    IGetsSingleNoId<WvwTimer>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwTimersTeamAssignment;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
