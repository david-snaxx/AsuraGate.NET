using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a foreground or background component used in guild emblems.</summary>
public record EmblemComponent
{
    /// <summary>Unique emblem component ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>List of image URLs for the color layers that compose this emblem component.</summary>
    [JsonPropertyName("layers")]
    public string[] Layers { get; init; } = [];
}
