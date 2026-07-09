using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>
/// Represents the kill and death statistics for a single guild in a WvW match team leaderboard,
/// as returned by the /v2/wvw/matches/stats/{id}/teams/{side}/top/{sort} endpoint.
/// </summary>
public record WvwMatchTeamGuildStats
{
    /// <summary>Guild ID of the ranked guild.</summary>
    [JsonPropertyName("guild_id")]
    public required string GuildId { get; init; }

    /// <summary>Kills this guild scored against each opposing team.</summary>
    [JsonPropertyName("kills")]
    public required WvwTeamValues Kills { get; init; }

    /// <summary>Deaths this guild suffered from each opposing team.</summary>
    [JsonPropertyName("deaths")]
    public required WvwTeamValues Deaths { get; init; }

    /// <summary>Wilson score used for KDR ranking; only present when sorting by "kdr".</summary>
    [JsonPropertyName("wilson")]
    public double? Wilson { get; init; }
}
