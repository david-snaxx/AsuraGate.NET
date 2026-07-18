using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Wvw;

// TId marked as int since the api expects world={int} as the query parameter
public sealed class WvwMatchWorldScoresRequest :
    IGetsSingle<WvwMatchWorldScores, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.WvwMatchScore;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
