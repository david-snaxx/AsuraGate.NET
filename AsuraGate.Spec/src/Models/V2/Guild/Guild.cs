using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Guild;

/// <summary>Represents a guild, including its public identity and (when authenticated) internal management data.</summary>
public record Guild
{
    /// <summary>Unique guild ID (UUID string).</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Full display name of the guild.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Four-character guild tag displayed in brackets next to character names.</summary>
    [JsonPropertyName("tag")]
    public required string Tag { get; init; }

    /// <summary>Guild emblem configuration; see <see cref="GuildEmblem"/>.</summary>
    [JsonPropertyName("emblem")]
    public GuildEmblem? Emblem { get; init; }

    /// <summary>Current guild level (1–25); null without a guild-scoped token.</summary>
    [JsonPropertyName("level")]
    public int? Level { get; init; }

    /// <summary>Guild message of the day; null without a guild-scoped token.</summary>
    [JsonPropertyName("motd")]
    public string? Motd { get; init; }

    /// <summary>Current influence stored in the guild vault; null without a guild-scoped token.</summary>
    [JsonPropertyName("influence")]
    public int? Influence { get; init; }

    /// <summary>Current aetherium stored in the guild vault; null without a guild-scoped token.</summary>
    [JsonPropertyName("aetherium")]
    public int? Aetherium { get; init; }

    /// <summary>Current guild favor; null without a guild-scoped token.</summary>
    [JsonPropertyName("favor")]
    public int? Favor { get; init; }

    /// <summary>Current resonance (Secrets of the Obscure guild currency); null without a guild-scoped token.</summary>
    [JsonPropertyName("resonance")]
    public int? Resonance { get; init; }

    /// <summary>Current number of members in the guild; null without a guild-scoped token.</summary>
    [JsonPropertyName("member_count")]
    public int? MemberCount { get; init; }

    /// <summary>Maximum number of members allowed in the guild; null without a guild-scoped token.</summary>
    [JsonPropertyName("member_capacity")]
    public int? MemberCapacity { get; init; }
}

/// <summary>Represents the emblem design of a <see cref="Guild"/>, composed of a background layer and a foreground layer.</summary>
public record GuildEmblem
{
    /// <summary>Background layer of the emblem.</summary>
    [JsonPropertyName("background")]
    public required EmblemLayer Background { get; init; }

    /// <summary>Foreground layer of the emblem.</summary>
    [JsonPropertyName("foreground")]
    public required EmblemLayer Foreground { get; init; }

    /// <summary>Transformation flags applied to the emblem (e.g., "FlipBackgroundHorizontal", "FlipForegroundVertical").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];
}

/// <summary>Represents a single layer (background or foreground) of a <see cref="GuildEmblem"/>.</summary>
public record EmblemLayer
{
    /// <summary>Emblem component ID identifying the graphic pattern; resolvable to an <see cref="EmblemComponent"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Dye color IDs applied to each color channel of this layer; each resolvable to a <see cref="Dye"/>.</summary>
    [JsonPropertyName("colors")]
    public int[] Colors { get; init; } = [];
}
