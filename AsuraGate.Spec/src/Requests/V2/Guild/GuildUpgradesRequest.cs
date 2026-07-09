using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Guild;

public sealed class GuildUpgradesRequest :
    IGetsSingle<GuildUpgrade, int>,
    IGetsBulk<GuildUpgrade, int>,
    IGetsAll<GuildUpgrade>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.GuildUpgrade;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
