using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class ItemStatRequest :
    IGetsSingle<ItemStat, int>,
    IGetsBulk<ItemStat, int>,
    IGetsAll<ItemStat>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.ItemStat;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
