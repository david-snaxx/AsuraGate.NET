using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Wvw;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatch"/>. Every <c>WvwTeamValues</c>
/// (a fixed red/blue/green tuple) is flattened into 3 columns per field; <c>AllWorlds</c>
/// (<c>WvwMultiTeamValues</c>, a variable list per team color) gets its own keyed child table.
/// </summary>
[Table("wvw_matches")]
public class WvwMatchEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("start_time")]
    public DateTime StartTime { get; set; }

    [NotNull]
    [Column("end_time")]
    public DateTime EndTime { get; set; }

    [NotNull]
    [Column("scores_red")]
    public int ScoresRed { get; set; }

    [NotNull]
    [Column("scores_blue")]
    public int ScoresBlue { get; set; }

    [NotNull]
    [Column("scores_green")]
    public int ScoresGreen { get; set; }

    [NotNull]
    [Column("worlds_red")]
    public int WorldsRed { get; set; }

    [NotNull]
    [Column("worlds_blue")]
    public int WorldsBlue { get; set; }

    [NotNull]
    [Column("worlds_green")]
    public int WorldsGreen { get; set; }

    [NotNull]
    [Column("deaths_red")]
    public int DeathsRed { get; set; }

    [NotNull]
    [Column("deaths_blue")]
    public int DeathsBlue { get; set; }

    [NotNull]
    [Column("deaths_green")]
    public int DeathsGreen { get; set; }

    [NotNull]
    [Column("kills_red")]
    public int KillsRed { get; set; }

    [NotNull]
    [Column("kills_blue")]
    public int KillsBlue { get; set; }

    [NotNull]
    [Column("kills_green")]
    public int KillsGreen { get; set; }

    [NotNull]
    [Column("victory_points_red")]
    public int VictoryPointsRed { get; set; }

    [NotNull]
    [Column("victory_points_blue")]
    public int VictoryPointsBlue { get; set; }

    [NotNull]
    [Column("victory_points_green")]
    public int VictoryPointsGreen { get; set; }
}

/// <summary>A linked world ID on a <see cref="WvwMatchEntity"/> team; <see cref="TeamColor"/> is "red"/"blue"/"green".</summary>
[Table("wvw_match_all_worlds")]
public class WvwMatchAllWorldEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("team_color")]
    public string TeamColor { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("world_id")]
    public int WorldId { get; set; }
}

/// <summary>A completed skirmish score record within a <see cref="WvwMatchEntity"/>; <see cref="SkirmishNumber"/> is the model's own sequential id.</summary>
[Table("wvw_match_skirmishes")]
public class WvwMatchSkirmishEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty;

    [NotNull]
    [Column("skirmish_number")]
    public int SkirmishNumber { get; set; }

    [NotNull]
    [Column("scores_red")]
    public int ScoresRed { get; set; }

    [NotNull]
    [Column("scores_blue")]
    public int ScoresBlue { get; set; }

    [NotNull]
    [Column("scores_green")]
    public int ScoresGreen { get; set; }
}

/// <summary>Per-map score contribution within a <see cref="WvwMatchSkirmishEntity"/>; carries (MatchId, SkirmishNumber) down instead of the skirmish's surrogate id.</summary>
[Table("wvw_match_skirmish_map_scores")]
public class WvwMatchSkirmishMapScoreEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("skirmish_number")]
    public int SkirmishNumber { get; set; }

    [NotNull]
    [Column("map_type")]
    public string MapType { get; set; } = string.Empty;

    [NotNull]
    [Column("scores_red")]
    public int ScoresRed { get; set; }

    [NotNull]
    [Column("scores_blue")]
    public int ScoresBlue { get; set; }

    [NotNull]
    [Column("scores_green")]
    public int ScoresGreen { get; set; }
}

/// <summary>A single WvW map's live state within a <see cref="WvwMatchEntity"/>.</summary>
[Table("wvw_match_maps")]
public class WvwMatchMapEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("scores_red")]
    public int ScoresRed { get; set; }

    [NotNull]
    [Column("scores_blue")]
    public int ScoresBlue { get; set; }

    [NotNull]
    [Column("scores_green")]
    public int ScoresGreen { get; set; }

    [NotNull]
    [Column("deaths_red")]
    public int DeathsRed { get; set; }

    [NotNull]
    [Column("deaths_blue")]
    public int DeathsBlue { get; set; }

    [NotNull]
    [Column("deaths_green")]
    public int DeathsGreen { get; set; }

    [NotNull]
    [Column("kills_red")]
    public int KillsRed { get; set; }

    [NotNull]
    [Column("kills_blue")]
    public int KillsBlue { get; set; }

    [NotNull]
    [Column("kills_green")]
    public int KillsGreen { get; set; }
}

/// <summary>An active bonus on a <see cref="WvwMatchMapEntity"/>; carries (MatchId, MapId) down.</summary>
[Table("wvw_match_map_bonuses")]
public class WvwMatchMapBonusEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("owner")]
    public string Owner { get; set; } = string.Empty;
}

/// <summary>Live state of a single objective on a <see cref="WvwMatchMapEntity"/>; carries (MatchId, MapId) down.</summary>
[Table("wvw_match_map_objectives")]
public class WvwMatchMapObjectiveEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull]
    [Indexed]
    [Column("objective_id")]
    public string ObjectiveId { get; set; } = string.Empty;

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("owner")]
    public string Owner { get; set; } = string.Empty;

    [NotNull]
    [Column("last_flipped")]
    public DateTime LastFlipped { get; set; }

    [Column("claimed_by")]
    public string? ClaimedBy { get; set; }

    [Column("claimed_at")]
    public DateTime? ClaimedAt { get; set; }

    [NotNull]
    [Column("points_tick")]
    public int PointsTick { get; set; }

    [NotNull]
    [Column("points_capture")]
    public int PointsCapture { get; set; }

    [NotNull]
    [Column("yaks_delivered")]
    public int YaksDelivered { get; set; }
}

/// <summary>A guild upgrade active on a <see cref="WvwMatchMapObjectiveEntity"/>; carries the objective's ObjectiveId down.</summary>
[Table("wvw_match_map_objective_guild_upgrades")]
public class WvwMatchMapObjectiveGuildUpgradeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("objective_id")]
    public string ObjectiveId { get; set; } = string.Empty;

    [NotNull]
    [Column("guild_upgrade_id")]
    public int GuildUpgradeId { get; set; }
}
