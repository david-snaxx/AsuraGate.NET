using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class ItemRequest :
    IGetsSingle<Item, int>,
    IGetsBulk<Item, int>,
    IGetsAll<Item>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Item;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
