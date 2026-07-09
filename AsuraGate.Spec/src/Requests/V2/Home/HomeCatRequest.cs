using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Home;

public sealed class HomeCatRequest :
    IGetsSingle<HomeCat, int>,
    IGetsBulk<HomeCat, int>,
    IGetsAll<HomeCat>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.HomeCat;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
