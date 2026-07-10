using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Commerce;

/// <summary>Represents the current buy and sell order price summary for a tradeable item on the Trading Post.</summary>
public record CommercePrice
{
    /// <summary>Item ID; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Whether this item is on the trading post whitelist (always tradeable regardless of item flags).</summary>
    [JsonPropertyName("whitelisted")]
    public required bool Whitelisted { get; init; }

    /// <summary>Aggregated buy order summary showing the highest active bid.</summary>
    [JsonPropertyName("buys")]
    public required PriceSummary Buys { get; init; }

    /// <summary>Aggregated sell order summary showing the lowest active ask.</summary>
    [JsonPropertyName("sells")]
    public required PriceSummary Sells { get; init; }
}

/// <summary>Represents the aggregate price and quantity for one side of the order book in a <see cref="CommercePrice"/>.</summary>
public record PriceSummary
{
    /// <summary>Best available price in copper coins (highest bid for buys, lowest ask for sells).</summary>
    [JsonPropertyName("unit_price")]
    public required int UnitPrice { get; init; }

    /// <summary>Total number of items offered at this price across all orders.</summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }
}
