using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a story season (e.g., a Living World season or expansion story arc) in GW2.</summary>
public record StorySeason
{
    /// <summary>Unique season identifier string (UUID format).</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of the season.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Display order among story seasons.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>List of story IDs belonging to this season; each resolvable via API:2/stories.</summary>
    [JsonPropertyName("stories")]
    public int[] Stories { get; init; } = [];
}
