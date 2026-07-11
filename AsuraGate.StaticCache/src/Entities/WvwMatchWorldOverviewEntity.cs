using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatchWorldOverview"/>.
/// </summary>
[Table("wvw_match_world_overviews")]
public class WvwMatchWorldOverviewEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty; // "{tier}-{position}"

    [NotNull, Indexed, Column("world_red")] public int WorldRed { get; set; } // FK to WorldEntity
    [NotNull, Indexed, Column("world_blue")] public int WorldBlue { get; set; } // FK to WorldEntity
    [NotNull, Indexed, Column("world_green")] public int WorldGreen { get; set; } // FK to WorldEntity

    [NotNull, Indexed, Column("start_time")]
    public DateTime StartTime { get; set; }

    [NotNull, Column("end_time")]
    public DateTime EndTime { get; set; }
}

/// <summary>A linked world on one team of a <see cref="WvwMatchWorldOverviewEntity"/>.</summary>
[Table("wvw_match_world_overview_all_worlds")]
public class WvwMatchWorldOverviewAllWorldEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("overview_id")]
    public string OverviewId { get; set; } = string.Empty; // FK to WvwMatchWorldOverviewEntity

    [NotNull, Indexed, Column("team")]
    public string Team { get; set; } = string.Empty;

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("world_id")]
    public int WorldId { get; set; } // FK to WorldEntity
}
