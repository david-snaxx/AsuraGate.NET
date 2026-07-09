using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents the full state snapshot of an active or completed WvW match, including scores, kill/death counts, objectives, and skirmish history.</summary>
public record WvwMatch
{
    /// <summary>Match ID in the format "{tier}-{position}" (e.g., "1-1", "2-3").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Timestamp when the match began.</summary>
    [JsonPropertyName("start_time")]
    public required DateTime StartTime { get; init; }

    /// <summary>Timestamp when the match ends or ended.</summary>
    [JsonPropertyName("end_time")]
    public required DateTime EndTime { get; init; }

    /// <summary>Total PPT scores accumulated by each team.</summary>
    [JsonPropertyName("scores")]
    public required WvwTeamValues Scores { get; init; }

    /// <summary>Primary world ID for each team (red/blue/green).</summary>
    [JsonPropertyName("worlds")]
    public required WvwTeamValues Worlds { get; init; }

    /// <summary>All world IDs for each team including linked worlds.</summary>
    [JsonPropertyName("all_worlds")]
    public required WvwMultiTeamValues AllWorlds { get; init; }

    /// <summary>Total deaths per team across all maps.</summary>
    [JsonPropertyName("deaths")]
    public required WvwTeamValues Deaths { get; init; }

    /// <summary>Total kills per team across all maps.</summary>
    [JsonPropertyName("kills")]
    public required WvwTeamValues Kills { get; init; }

    /// <summary>Current victory point totals per team.</summary>
    [JsonPropertyName("victory_points")]
    public required WvwTeamValues VictoryPoints { get; init; }

    /// <summary>Ordered list of completed skirmish score records.</summary>
    [JsonPropertyName("skirmishes")]
    public WvwSkirmish[] Skirmishes { get; init; } = [];

    /// <summary>Per-map breakdown of objectives, bonuses, and stats.</summary>
    [JsonPropertyName("maps")]
    public WvwMatchMap[] Maps { get; init; } = [];
}

/// <summary>Represents a single integer value per WvW team color.</summary>
public record WvwTeamValues
{
    /// <summary>Value for the red team.</summary>
    [JsonPropertyName("red")]
    public required int Red { get; init; }

    /// <summary>Value for the blue team.</summary>
    [JsonPropertyName("blue")]
    public required int Blue { get; init; }

    /// <summary>Value for the green team.</summary>
    [JsonPropertyName("green")]
    public required int Green { get; init; }
}

/// <summary>Represents a list of world IDs per WvW team color, including all linked worlds.</summary>
public record WvwMultiTeamValues
{
    /// <summary>World IDs on the red team (primary world plus any linked worlds).</summary>
    [JsonPropertyName("red")]
    public int[] Red { get; init; } = [];

    /// <summary>World IDs on the blue team (primary world plus any linked worlds).</summary>
    [JsonPropertyName("blue")]
    public int[] Blue { get; init; } = [];

    /// <summary>World IDs on the green team (primary world plus any linked worlds).</summary>
    [JsonPropertyName("green")]
    public int[] Green { get; init; } = [];
}

/// <summary>Represents the score record for a single skirmish period within a <see cref="WvwMatch"/>.</summary>
public record WvwSkirmish
{
    /// <summary>Sequential skirmish number within the match (1-based).</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Points scored by each team during this skirmish.</summary>
    [JsonPropertyName("scores")]
    public required WvwTeamValues Scores { get; init; }

    /// <summary>Per-map score breakdown for this skirmish.</summary>
    [JsonPropertyName("map_scores")]
    public WvwMapScore[] MapScores { get; init; } = [];
}

/// <summary>Represents the per-map score contribution during a <see cref="WvwSkirmish"/>.</summary>
public record WvwMapScore
{
    /// <summary>Map type identifier (e.g., "Center", "RedHome", "BlueHome", "GreenHome").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Points scored by each team on this map during the skirmish.</summary>
    [JsonPropertyName("scores")]
    public required WvwTeamValues Scores { get; init; }
}

/// <summary>Represents a single WvW map's current state within a <see cref="WvwMatch"/>.</summary>
public record WvwMatchMap
{
    /// <summary>Map ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Map type identifier (e.g., "Center", "RedHome", "BlueHome", "GreenHome").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Current total scores per team on this map.</summary>
    [JsonPropertyName("scores")]
    public required WvwTeamValues Scores { get; init; }

    /// <summary>Active map bonuses (e.g., Bloodlust).</summary>
    [JsonPropertyName("bonuses")]
    public WvwBonus[] Bonuses { get; init; } = [];

    /// <summary>Current objective states on this map.</summary>
    [JsonPropertyName("objectives")]
    public WvwMatchObjective[] Objectives { get; init; } = [];

    /// <summary>Total deaths per team on this map.</summary>
    [JsonPropertyName("deaths")]
    public required WvwTeamValues Deaths { get; init; }

    /// <summary>Total kills per team on this map.</summary>
    [JsonPropertyName("kills")]
    public required WvwTeamValues Kills { get; init; }
}

/// <summary>Represents an active map bonus within a <see cref="WvwMatchMap"/>.</summary>
public record WvwBonus
{
    /// <summary>Bonus type identifier (e.g., "Bloodlust").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Team color currently controlling the bonus: "Red", "Blue", or "Green".</summary>
    [JsonPropertyName("owner")]
    public required string Owner { get; init; }
}

/// <summary>Represents the live state of a single objective within a <see cref="WvwMatchMap"/>.</summary>
public record WvwMatchObjective
{
    /// <summary>Objective ID; matches the <see cref="WvwObjective"/> ID.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Objective type (e.g., "Camp", "Tower", "Keep", "Castle").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Team currently holding this objective: "Red", "Blue", "Green", or "Neutral".</summary>
    [JsonPropertyName("owner")]
    public required string Owner { get; init; }

    /// <summary>Timestamp when ownership of this objective last changed.</summary>
    [JsonPropertyName("last_flipped")]
    public required DateTime LastFlipped { get; init; }

    /// <summary>Guild ID of the guild that has claimed this objective; null if unclaimed.</summary>
    [JsonPropertyName("claimed_by")]
    public string? ClaimedBy { get; init; }

    /// <summary>Timestamp when the guild claimed this objective; null if unclaimed.</summary>
    [JsonPropertyName("claimed_at")]
    public DateTime? ClaimedAt { get; init; }

    /// <summary>Points per tick (PPT) this objective contributes toward the owning team's score.</summary>
    [JsonPropertyName("points_tick")]
    public required int PointsTick { get; init; }

    /// <summary>Bonus points awarded to the capturing team at the moment of capture.</summary>
    [JsonPropertyName("points_capture")]
    public required int PointsCapture { get; init; }

    /// <summary>Number of dolyaks successfully delivered to this objective.</summary>
    [JsonPropertyName("yaks_delivered")]
    public required int YaksDelivered { get; init; }

    /// <summary>Guild upgrade IDs currently active on this objective; each resolvable to a <see cref="GuildUpgrade"/>.</summary>
    [JsonPropertyName("guild_upgrades")]
    public int[] GuildUpgrades { get; init; } = [];
}
