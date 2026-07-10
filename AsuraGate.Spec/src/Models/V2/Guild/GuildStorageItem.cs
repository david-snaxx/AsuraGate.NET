using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Guild;

/// <summary>Represents an item stored in the guild's decoration storage (homestead decorations collected by the guild).</summary>
public record GuildStorageItem
{
    /// <summary>Decoration or item ID; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Number of this item currently held in the guild's storage.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
