using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a Jade Bot skin, a cosmetic customization for the Jade Bot companion introduced in the End of Dragons expansion.</summary>
public record JadeBot
{
    /// <summary>Unique Jade Bot skin ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of this Jade Bot skin.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the skin's appearance.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Item ID used to unlock this Jade Bot skin; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("unlock_item")]
    public required int UnlockItem { get; init; }
}
