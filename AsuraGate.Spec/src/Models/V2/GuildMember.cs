using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a member of a guild.</summary>
public record GuildMember
{
    /// <summary>Account display name of the member (e.g., "PlayerName.1234").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Name of the guild rank currently held by this member.</summary>
    [JsonPropertyName("rank")]
    public required string Rank { get; init; }

    /// <summary>Timestamp of when this member joined the guild.</summary>
    [JsonPropertyName("joined")]
    public required DateTime Joined { get; init; }

    /// <summary>Whether this member has opted in to WvW guild membership.</summary>
    [JsonPropertyName("wvw_member")]
    public required bool WvwMember { get; init; }
}
