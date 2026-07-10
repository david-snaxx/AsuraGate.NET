using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Commerce;

/// <summary>Represents the current gem-to-coin (or coin-to-gem) exchange rate from the Gem Store.</summary>
public record CommerceExchange
{
    /// <summary>Number of copper coins equivalent to one gem at the current exchange rate.</summary>
    [JsonPropertyName("coins_per_gem")]
    public required int CoinsPerGem { get; init; }

    /// <summary>Number of gems (or coins) that would be received for the queried amount.</summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }
}
