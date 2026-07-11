using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatchWorldScores"/>.
/// </summary>
[Table("wvw_match_world_scores")]
public class WvwMatchWorldScoresEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty; // "{tier}-{position}"

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }
    [NotNull, Column("scores_green")] public int ScoresGreen { get; set; }

    [NotNull, Column("victory_points_red")] public int VictoryPointsRed { get; set; }
    [NotNull, Column("victory_points_blue")] public int VictoryPointsBlue { get; set; }
    [NotNull, Column("victory_points_green")] public int VictoryPointsGreen { get; set; }
}

/// <summary>A completed skirmish score record within a <see cref="WvwMatchWorldScoresEntity"/>.</summary>
[Table("wvw_match_world_scores_skirmishes")]
public class WvwMatchWorldScoresSkirmishEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed(Name = "ux_wvw_match_world_scores_skirmishes_scores_id_skirmish_number", Order = 1, Unique = true)]
    [Column("world_scores_id")]
    public string WorldScoresId { get; set; } = string.Empty; // FK to WvwMatchWorldScoresEntity

    [NotNull]
    [Indexed(Name = "ux_wvw_match_world_scores_skirmishes_scores_id_skirmish_number", Order = 2, Unique = true)]
    [Column("skirmish_number")]
    public int SkirmishNumber { get; set; }

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }
    [NotNull, Column("scores_green")] public int ScoresGreen { get; set; }
}

/// <summary>A per-map score contribution within a <see cref="WvwMatchWorldScoresSkirmishEntity"/>.</summary>
[Table("wvw_match_world_scores_skirmish_map_scores")]
public class WvwMatchWorldScoresSkirmishMapScoreEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skirmish_id")]
    public int SkirmishId { get; set; } // FK to WvwMatchWorldScoresSkirmishEntity

    [NotNull, Indexed, Column("map_type")]
    public string MapType { get; set; } = string.Empty;

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }
    [NotNull, Column("scores_green")] public int ScoresGreen { get; set; }
}

/// <summary>The total score for a single map within a <see cref="WvwMatchWorldScoresEntity"/>.</summary>
[Table("wvw_match_world_scores_maps")]
public class WvwMatchWorldScoresMapEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed(Name = "ux_wvw_match_world_scores_maps_scores_id_map_id", Order = 1, Unique = true)]
    [Column("world_scores_id")]
    public string WorldScoresId { get; set; } = string.Empty; // FK to WvwMatchWorldScoresEntity

    [NotNull]
    [Indexed(Name = "ux_wvw_match_world_scores_maps_scores_id_map_id", Order = 2, Unique = true)]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull, Indexed, Column("map_type")]
    public string MapType { get; set; } = string.Empty;

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }
    [NotNull, Column("scores_green")] public int ScoresGreen { get; set; }
}
