using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Guild;

public class GuildStashRequest :
    IGetsSingleNoId<IEnumerable<GuildStashSection>>
{
    public string EndpointUrl { get; }
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
    
    public GuildStashRequest(string guildId)
    {
        if (string.IsNullOrWhiteSpace(guildId))
            throw new ArgumentException("Guild ID cannot be null or empty.", nameof(guildId));
        EndpointUrl = Gw2ApiEndpointUrl.GuildStash.Replace("{id}", Uri.EscapeDataString(guildId));
    }
}
