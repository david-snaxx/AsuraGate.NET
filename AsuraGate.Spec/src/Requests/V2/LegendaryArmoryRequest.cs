using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class LegendaryArmoryRequest :
    IGetsSingle<LegendaryArmoryItem, int>,
    IGetsBulk<LegendaryArmoryItem, int>,
    IGetsAll<LegendaryArmoryItem>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.LegendaryArmory;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
