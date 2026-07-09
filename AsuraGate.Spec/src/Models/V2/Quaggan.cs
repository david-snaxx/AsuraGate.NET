using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a Quaggan image resource from the GW2 API.</summary>
public record Quaggan
{
    /// <summary>Unique Quaggan identifier string (e.g., "404", "cheer").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>URL to the Quaggan image.</summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
