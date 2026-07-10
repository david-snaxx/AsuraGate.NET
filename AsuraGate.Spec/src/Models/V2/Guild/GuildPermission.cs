using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Guild;

/// <summary>Represents a guild permission that can be assigned to guild ranks.</summary>
public record GuildPermission
{
    /// <summary>Unique permission identifier string (e.g., "EditBGOTD", "ActivatePlaceables").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of this permission.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of what this permission allows a guild member to do.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }
}
