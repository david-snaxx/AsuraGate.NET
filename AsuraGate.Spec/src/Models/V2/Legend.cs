using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a Revenant legend, which determines the skills available while that legend is active.</summary>
public record Legend
{
    /// <summary>Unique legend identifier string (e.g., "Legend1").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Template code integer for this legend; null for some legends.</summary>
    [JsonPropertyName("code")]
    public int? Code { get; init; }

    /// <summary>Skill ID of the legend swap ability; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("swap")]
    public required int Swap { get; init; }

    /// <summary>Skill ID of the heal skill for this legend; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("heal")]
    public required int Heal { get; init; }

    /// <summary>Skill ID of the elite skill for this legend; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("elite")]
    public required int Elite { get; init; }

    /// <summary>List of utility skill IDs for this legend; each resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("utilities")]
    public int[] Utilities { get; init; } = [];
}
