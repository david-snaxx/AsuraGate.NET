using SQLite;

namespace AsuraGate.Spec.Entities.V2.Wvw;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatchWorldOverview"/>.
/// </summary>
[Table("wvw_match_world_overviews")]
public class WvwMatchWorldOverviewEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

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
    [Column("start_time")]
    public DateTime StartTime { get; set; }

    [NotNull]
    [Column("end_time")]
    public DateTime EndTime { get; set; }
}

/// <summary>A linked world ID on a <see cref="WvwMatchWorldOverviewEntity"/> team.</summary>
[Table("wvw_match_world_overview_all_worlds")]
public class WvwMatchWorldOverviewAllWorldEntity
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
