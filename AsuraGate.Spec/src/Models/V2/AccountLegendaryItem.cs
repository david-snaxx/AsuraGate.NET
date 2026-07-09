using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a legendary item stored in the authenticated account's legendary armory.</summary>
public record AccountLegendaryItem
{
    /// <summary>Item ID of the legendary item; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Number of this legendary item stored in the armory.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
