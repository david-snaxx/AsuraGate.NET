using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class MaterialRequest :
    IGetsSingle<MaterialCategory, int>,
    IGetsBulk<MaterialCategory, int>,
    IGetsAll<MaterialCategory>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Material;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
