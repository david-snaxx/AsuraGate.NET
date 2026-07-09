using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a single Trading Post buy or sell order, either currently open or from the transaction history.</summary>
public record CommerceTransaction
{
    /// <summary>Unique transaction ID.</summary>
    [JsonPropertyName("id")]
    public required long Id { get; init; }

    /// <summary>Item ID of the order; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }

    /// <summary>Price per item in copper coins.</summary>
    [JsonPropertyName("price")]
    public required int Price { get; init; }

    /// <summary>Number of items in this order.</summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }

    /// <summary>Timestamp when this order was placed on the Trading Post.</summary>
    [JsonPropertyName("created")]
    public required DateTime Created { get; init; }

    /// <summary>Timestamp when this order was fulfilled; null for orders that are still open.</summary>
    [JsonPropertyName("purchased")]
    public DateTime? Purchased { get; init; }
}
