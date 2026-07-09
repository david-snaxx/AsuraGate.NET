using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents the full order book listings for a tradeable item on the Trading Post.</summary>
public record CommerceListing
{
    /// <summary>Item ID; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Active buy orders sorted from highest to lowest bid price.</summary>
    [JsonPropertyName("buys")]
    public ListingEntry[] Buys { get; init; } = [];

    /// <summary>Active sell orders sorted from lowest to highest ask price.</summary>
    [JsonPropertyName("sells")]
    public ListingEntry[] Sells { get; init; } = [];
}

/// <summary>Represents a single price level in the Trading Post order book within <see cref="CommerceListing"/>.</summary>
public record ListingEntry
{
    /// <summary>Number of individual orders placed at this exact price level.</summary>
    [JsonPropertyName("listings")]
    public required int Listings { get; init; }

    /// <summary>Price per item in copper coins at this listing level.</summary>
    [JsonPropertyName("unit_price")]
    public required int UnitPrice { get; init; }

    /// <summary>Total number of items available across all orders at this price level.</summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }
}
