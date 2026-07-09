using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a playable race in GW2 and the racial skills it provides.</summary>
public record Race
{
    /// <summary>Race identifier string (e.g., "Asura", "Human", "Norn", "Charr", "Sylvari").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>List of racial skill IDs available to this race; each resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("skills")]
    public int[] Skills { get; init; } = [];
}
