using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class FileRequest :
    IGetsSingle<ApiFile, string>,
    IGetsBulk<ApiFile, string>,
    IGetsAll<ApiFile>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.File;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
