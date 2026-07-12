using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Guild;

public sealed class GuildPermissionRequest :
    IGetsSingle<GuildPermission, string>,
    IGetsBulk<GuildPermission, string>,
    IGetsAll<GuildPermission, string>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.GuildPermission;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
