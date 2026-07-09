using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class LogoRequest :
    IGetsSingle<Logo, string>,
    IGetsBulk<Logo, string>,
    IGetsAll<Logo>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Logo;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
