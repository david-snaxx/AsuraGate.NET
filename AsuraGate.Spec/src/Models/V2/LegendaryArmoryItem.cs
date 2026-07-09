using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a legendary item that can be registered in the account's Legendary Armory for shared use across characters.</summary>
public record LegendaryArmoryItem
{
    /// <summary>Item ID of the legendary item; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Maximum number of copies of this legendary item that can be registered simultaneously in the armory.</summary>
    [JsonPropertyName("max_count")]
    public required int MaxCount { get; init; }
}
