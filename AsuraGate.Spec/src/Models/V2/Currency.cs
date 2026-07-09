using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a wallet currency in GW2 (e.g., Karma, Laurels, Fractal Relics).</summary>
public record Currency
{
    /// <summary>Unique currency ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the currency.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Short description of how the currency is earned or used.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>URL to the currency icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Display order within the wallet UI.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }
}
