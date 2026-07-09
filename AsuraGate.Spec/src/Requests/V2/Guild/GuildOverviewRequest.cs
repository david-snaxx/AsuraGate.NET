using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Guild;

public class GuildOverviewRequest :
    IGetsSingleNoId<Models.V2.Guild>
{
    public string EndpointUrl { get; }
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
    
    public GuildOverviewRequest(string guildId)
    {
        if (string.IsNullOrWhiteSpace(guildId))
            throw new ArgumentException("Guild ID cannot be null or empty.", nameof(guildId));
        EndpointUrl = Gw2ApiEndpointUrl.Guild.Replace("{id}", Uri.EscapeDataString(guildId));
    }
}
