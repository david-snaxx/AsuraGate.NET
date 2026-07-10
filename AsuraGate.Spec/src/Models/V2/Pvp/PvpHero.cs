using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Pvp;

/// <summary>Represents a PvP battle hero — a cosmetic avatar used in structured PvP matches.</summary>
public record PvpHero
{
    /// <summary>Unique hero ID (UUID string).</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of the hero.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Flavor text description of the hero.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Hero archetype or category.</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Combat stat ratings for this hero.</summary>
    [JsonPropertyName("stats")]
    public required PvpHeroStats Stats { get; init; }

    /// <summary>URL to the hero's overlay image (displayed on top of the hero portrait).</summary>
    [JsonPropertyName("overlay")]
    public required string Overlay { get; init; }

    /// <summary>URL to the hero's underlay image (displayed behind the hero portrait).</summary>
    [JsonPropertyName("underlay")]
    public required string Underlay { get; init; }

    /// <summary>Available cosmetic skins for this hero.</summary>
    [JsonPropertyName("skins")]
    public PvpHeroSkin[] Skins { get; init; } = [];
}

/// <summary>Represents the combat stat ratings for a <see cref="PvpHero"/>.</summary>
public record PvpHeroStats
{
    /// <summary>Offensive power rating (0–5 scale).</summary>
    [JsonPropertyName("offense")]
    public required int Offense { get; init; }

    /// <summary>Defensive durability rating (0–5 scale).</summary>
    [JsonPropertyName("defense")]
    public required int Defense { get; init; }

    /// <summary>Movement speed rating (0–5 scale).</summary>
    [JsonPropertyName("speed")]
    public required int Speed { get; init; }
}

/// <summary>Represents a single cosmetic skin available for a <see cref="PvpHero"/>.</summary>
public record PvpHeroSkin
{
    /// <summary>Unique skin ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of this skin.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>URL to the skin's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>True if this is the hero's default skin (always unlocked).</summary>
    [JsonPropertyName("default")]
    public required bool IsDefault { get; init; }

    /// <summary>Item IDs that can be consumed to unlock this skin; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("unlock_items")]
    public int[] UnlockItems { get; init; } = [];
}
