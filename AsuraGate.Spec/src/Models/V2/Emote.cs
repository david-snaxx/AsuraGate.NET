using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents an emote animation that a character can perform.</summary>
public record Emote
{
    /// <summary>Unique emote ID string (e.g., "beckon", "cheer").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>List of chat commands that trigger this emote (e.g., "/beckon").</summary>
    [JsonPropertyName("commands")]
    public string[] Commands { get; init; } = [];

    /// <summary>List of item IDs that can be consumed to unlock this emote; each resolvable to an <see cref="Item"/>; empty if the emote is available by default.</summary>
    [JsonPropertyName("unlock_items")]
    public int[] UnlockItems { get; init; } = [];
}
