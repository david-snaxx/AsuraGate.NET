using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatch"/>. This is live match state, so a
/// repository refreshing a match should re-fetch and overwrite its full row graph rather than diff it.
/// </summary>
[Table("wvw_matches")]
public class WvwMatchEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty; // "{tier}-{position}", e.g. "1-1"

    [NotNull, Indexed, Column("start_time")]
    public DateTime StartTime { get; set; }

    [NotNull, Column("end_time")]
    public DateTime EndTime { get; set; }

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }
    [NotNull, Column("scores_green")] public int ScoresGreen { get; set; }

    [NotNull, Indexed, Column("world_red")] public int WorldRed { get; set; } // FK to WorldEntity
    [NotNull, Indexed, Column("world_blue")] public int WorldBlue { get; set; } // FK to WorldEntity
    [NotNull, Indexed, Column("world_green")] public int WorldGreen { get; set; } // FK to WorldEntity

    [NotNull, Column("deaths_red")] public int DeathsRed { get; set; }
    [NotNull, Column("deaths_blue")] public int DeathsBlue { get; set; }
    [NotNull, Column("deaths_green")] public int DeathsGreen { get; set; }

    [NotNull, Column("kills_red")] public int KillsRed { get; set; }
    [NotNull, Column("kills_blue")] public int KillsBlue { get; set; }
    [NotNull, Column("kills_green")] public int KillsGreen { get; set; }

    [NotNull, Column("victory_points_red")] public int VictoryPointsRed { get; set; }
    [NotNull, Column("victory_points_blue")] public int VictoryPointsBlue { get; set; }
    [NotNull, Column("victory_points_green")] public int VictoryPointsGreen { get; set; }
}

/// <summary>A linked world on one team of a <see cref="WvwMatchEntity"/> (the primary world plus any linked worlds).</summary>
[Table("wvw_match_all_worlds")]
public class WvwMatchAllWorldEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("match_id")]
    public string MatchId { get; set; } = string.Empty; // FK to WvwMatchEntity

    [NotNull, Indexed, Column("team")]
    public string Team { get; set; } = string.Empty; // "Red", "Blue", "Green"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("world_id")]
    public int WorldId { get; set; } // FK to WorldEntity
}

/// <summary>A completed skirmish score record within a <see cref="WvwMatchEntity"/>.</summary>
[Table("wvw_match_skirmishes")]
public class WvwMatchSkirmishEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_wvw_match_skirmishes_match_id_skirmish_number", Order = 1, Unique = true)]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty; // FK to WvwMatchEntity

    [NotNull]
    [Indexed(Name = "ux_wvw_match_skirmishes_match_id_skirmish_number", Order = 2, Unique = true)]
    [Column("skirmish_number")]
    public int SkirmishNumber { get; set; } // api "id" value

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }
    [NotNull, Column("scores_green")] public int ScoresGreen { get; set; }
}

/// <summary>A per-map score contribution within a <see cref="WvwMatchSkirmishEntity"/>.</summary>
[Table("wvw_match_skirmish_map_scores")]
public class WvwMatchSkirmishMapScoreEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skirmish_id")]
    public int SkirmishId { get; set; } // FK to WvwMatchSkirmishEntity

    [NotNull, Indexed, Column("map_type")]
    public string MapType { get; set; } = string.Empty;

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }
    [NotNull, Column("scores_green")] public int ScoresGreen { get; set; }
}

/// <summary>A single WvW map's current state within a <see cref="WvwMatchEntity"/>.</summary>
[Table("wvw_match_maps")]
public class WvwMatchMapEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_wvw_match_maps_match_id_map_id", Order = 1, Unique = true)]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty; // FK to WvwMatchEntity

    [NotNull]
    [Indexed(Name = "ux_wvw_match_maps_match_id_map_id", Order = 2, Unique = true)]
    [Column("map_id")]
    public int MapId { get; set; } // api "id" value

    [NotNull, Indexed, Column("map_type")]
    public string MapType { get; set; } = string.Empty;

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }
    [NotNull, Column("scores_green")] public int ScoresGreen { get; set; }

    [NotNull, Column("deaths_red")] public int DeathsRed { get; set; }
    [NotNull, Column("deaths_blue")] public int DeathsBlue { get; set; }
    [NotNull, Column("deaths_green")] public int DeathsGreen { get; set; }

    [NotNull, Column("kills_red")] public int KillsRed { get; set; }
    [NotNull, Column("kills_blue")] public int KillsBlue { get; set; }
    [NotNull, Column("kills_green")] public int KillsGreen { get; set; }
}

/// <summary>An active map bonus (e.g. Bloodlust) within a <see cref="WvwMatchMapEntity"/>.</summary>
[Table("wvw_match_map_bonuses")]
public class WvwMatchMapBonusEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("match_map_id")]
    public int MatchMapId { get; set; } // FK to WvwMatchMapEntity

    [NotNull, Indexed, Column("bonus_type")]
    public string BonusType { get; set; } = string.Empty;

    [NotNull, Column("owner")]
    public string Owner { get; set; } = string.Empty;
}

/// <summary>The live state of a single objective within a <see cref="WvwMatchMapEntity"/>.</summary>
[Table("wvw_match_map_objectives")]
public class WvwMatchMapObjectiveEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_wvw_match_map_objectives_map_id_objective_id", Order = 1, Unique = true)]
    [Column("match_map_id")]
    public int MatchMapId { get; set; } // FK to WvwMatchMapEntity

    [NotNull]
    [Indexed(Name = "ux_wvw_match_map_objectives_map_id_objective_id", Order = 2, Unique = true)]
    [Column("objective_id")]
    public string ObjectiveId { get; set; } = string.Empty; // FK to WvwObjectiveEntity

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull, Indexed, Column("owner")]
    public string Owner { get; set; } = string.Empty;

    [NotNull, Column("last_flipped")]
    public DateTime LastFlipped { get; set; }

    [Indexed, Column("claimed_by")]
    public string? ClaimedBy { get; set; } // FK to GuildEntity

    [Column("claimed_at")]
    public DateTime? ClaimedAt { get; set; }

    [NotNull, Column("points_tick")]
    public int PointsTick { get; set; }

    [NotNull, Column("points_capture")]
    public int PointsCapture { get; set; }

    [NotNull, Column("yaks_delivered")]
    public int YaksDelivered { get; set; }
}

/// <summary>A guild upgrade currently active on a <see cref="WvwMatchMapObjectiveEntity"/>.</summary>
[Table("wvw_match_map_objective_guild_upgrades")]
public class WvwMatchMapObjectiveGuildUpgradeEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("match_map_objective_id")]
    public int MatchMapObjectiveId { get; set; } // FK to WvwMatchMapObjectiveEntity

    [NotNull, Indexed, Column("guild_upgrade_id")]
    public int GuildUpgradeId { get; set; } // FK to GuildUpgradeEntity
}
