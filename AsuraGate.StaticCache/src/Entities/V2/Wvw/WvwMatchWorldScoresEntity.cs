using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Wvw;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatchWorldScores"/>.
/// </summary>
[Table("wvw_match_world_scores")]
public class WvwMatchWorldScoresEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

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
    [Column("victory_points_red")]
    public int VictoryPointsRed { get; set; }

    [NotNull]
    [Column("victory_points_blue")]
    public int VictoryPointsBlue { get; set; }

    [NotNull]
    [Column("victory_points_green")]
    public int VictoryPointsGreen { get; set; }
}

/// <summary>A completed skirmish score record within a <see cref="WvwMatchWorldScoresEntity"/>.</summary>
[Table("wvw_match_world_scores_skirmishes")]
public class WvwMatchWorldScoresSkirmishEntity
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

/// <summary>Per-map score contribution within a <see cref="WvwMatchWorldScoresSkirmishEntity"/>; carries (MatchId, SkirmishNumber) down.</summary>
[Table("wvw_match_world_scores_skirmish_maps")]
public class WvwMatchWorldScoresSkirmishMapEntity
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

/// <summary>Total score for a single map within a <see cref="WvwMatchWorldScoresEntity"/>.</summary>
[Table("wvw_match_world_scores_maps")]
public class WvwMatchWorldScoresMapEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty;

    [NotNull]
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
}
