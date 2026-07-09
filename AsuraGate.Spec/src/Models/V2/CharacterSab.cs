using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a character's Super Adventure Box (SAB) progress, including completed zones and purchased upgrades.</summary>
public record CharacterSab
{
    /// <summary>SAB zones this character has completed.</summary>
    [JsonPropertyName("zones")]
    public SabZone[] Zones { get; init; } = [];

    /// <summary>Permanent SAB upgrades this character has purchased.</summary>
    [JsonPropertyName("unlocks")]
    public SabUnlock[] Unlocks { get; init; } = [];

    /// <summary>SAB flute songs this character has unlocked.</summary>
    [JsonPropertyName("songs")]
    public SabSong[] Songs { get; init; } = [];
}

/// <summary>Represents a completed SAB zone entry within <see cref="CharacterSab"/>.</summary>
public record SabZone
{
    /// <summary>Unique zone completion ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Difficulty mode completed: "normal" or "tribulation".</summary>
    [JsonPropertyName("mode")]
    public required string Mode { get; init; }

    /// <summary>SAB world number (1 or 2).</summary>
    [JsonPropertyName("world")]
    public required int World { get; init; }

    /// <summary>Zone number within the world (1–3 for world 1, 1–3 for world 2).</summary>
    [JsonPropertyName("zone")]
    public required int Zone { get; init; }
}

/// <summary>Represents a permanent SAB upgrade purchased by the character within <see cref="CharacterSab"/>.</summary>
public record SabUnlock
{
    /// <summary>Unique upgrade ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the upgrade (e.g., "Whip", "Torch", "Cannonball").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}

/// <summary>Represents a flute song unlocked by the character within <see cref="CharacterSab"/>.</summary>
public record SabSong
{
    /// <summary>Unique song ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the song.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
