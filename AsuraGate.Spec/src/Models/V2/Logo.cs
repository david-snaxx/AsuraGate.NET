using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a logo image asset from the GW2 API.</summary>
public record Logo
{
    /// <summary>Unique logo identifier string.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>URL to the logo image.</summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
