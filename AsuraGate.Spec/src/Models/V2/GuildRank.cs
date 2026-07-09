using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a rank within a guild, defining the permissions granted to members holding that rank.</summary>
public record GuildRank
{
    /// <summary>Unique name of this rank as set by the guild leader (e.g., "Leader", "Officer", "Member").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display order index used to sort this rank in the roster; lower values indicate higher-ranking positions.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>Permission IDs granted to this rank; each resolvable to a <see cref="GuildPermission"/>.</summary>
    [JsonPropertyName("permissions")]
    public string[] Permissions { get; init; } = [];

    /// <summary>URL to the rank's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }
}
