using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Commerce;

/// <summary>Represents the contents of the authenticated account's Trading Post delivery box awaiting collection.</summary>
public record CommerceDelivery
{
    /// <summary>Total coin amount (in copper) awaiting collection from fulfilled sell orders.</summary>
    [JsonPropertyName("coins")]
    public required long Coins { get; init; }

    /// <summary>Items awaiting collection from fulfilled buy orders.</summary>
    [JsonPropertyName("items")]
    public DeliveryItem[] Items { get; init; } = [];
}

/// <summary>Represents a single item pending collection in the Trading Post delivery box within <see cref="CommerceDelivery"/>.</summary>
public record DeliveryItem
{
    /// <summary>Item ID awaiting collection; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Number of this item in the delivery box.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
