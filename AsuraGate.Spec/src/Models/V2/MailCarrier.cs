using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a mail carrier cosmetic that customizes the appearance of in-game mail delivery.</summary>
public record MailCarrier
{
    /// <summary>Unique mail carrier ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the mail carrier.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>URL to the mail carrier icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Display order in the mail carrier panel.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>List of item IDs that unlock this mail carrier; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("unlock_items")]
    public int[] UnlockItems { get; init; } = [];

    /// <summary>List of behavior flags (e.g., "Default").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];
}
