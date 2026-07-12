using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class ContinentFloorRequest :
    IGetsSingle<ContinentFloor, int>,
    IGetsBulk<ContinentFloor, int>,
    IGetsAll<ContinentFloor, int>,
    IGetsIds<int>
{
    public string EndpointUrl { get; }
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
    
    public ContinentFloorRequest(int continentId)
    {
        if (continentId < 0)
            throw new ArgumentException("Continent ID cannot be negative.", nameof(continentId));
        EndpointUrl = Gw2ApiEndpointUrl.ContinentFloor.Replace("{id}", continentId.ToString());
    }
}