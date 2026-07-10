using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Account;

/// <summary>Represents a finisher unlocked on the authenticated account.</summary>
public record AccountFinisher
{
    /// <summary>Finisher ID; resolvable to a <see cref="Finisher"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Whether this finisher is permanently unlocked (true) or is a temporary consumable (false).</summary>
    [JsonPropertyName("permanent")]
    public required bool Permanent { get; init; }

    /// <summary>Number of uses remaining for temporary finishers; null for permanent finishers.</summary>
    [JsonPropertyName("quantity")]
    public int? Quantity { get; init; }
}
