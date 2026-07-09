using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a miniature (mini pet) collectible that follows the character.</summary>
public record Mini
{
    /// <summary>Unique miniature ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the miniature.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Unlock hint or description; null or empty for some miniatures.</summary>
    [JsonPropertyName("unlock")]
    public string? Unlock { get; init; }

    /// <summary>URL to the miniature icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Display order in the miniature collection panel.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>ID of the miniature's associated unlock item; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }
}
