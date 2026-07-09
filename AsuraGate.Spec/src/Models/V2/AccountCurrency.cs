using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a single currency balance in the authenticated account's wallet.</summary>
public record AccountCurrency
{
    /// <summary>Currency ID; resolvable to a <see cref="Currency"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Current amount of this currency held in the wallet.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}
