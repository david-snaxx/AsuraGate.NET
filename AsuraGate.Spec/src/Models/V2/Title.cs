using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a character title displayable below a player's name.</summary>
public record Title
{
    /// <summary>Unique title ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display text of the title.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Legacy single-achievement ID that unlocks this title; resolvable via API:2/achievements; null if not unlocked via a single achievement.</summary>
    [JsonPropertyName("achievement")]
    public int? Achievement { get; init; }

    /// <summary>List of achievement IDs that can unlock this title; each resolvable via API:2/achievements.</summary>
    [JsonPropertyName("achievements")]
    public int[] Achievements { get; init; } = [];

    /// <summary>Achievement point threshold required to unlock this title; null if not AP-gated.</summary>
    [JsonPropertyName("ap_required")]
    public int? ApRequired { get; init; }
}
