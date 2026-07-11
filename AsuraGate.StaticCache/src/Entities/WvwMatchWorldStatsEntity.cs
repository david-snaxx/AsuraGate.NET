using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatchWorldStats"/>.
/// </summary>
[Table("wvw_match_world_stats")]
public class WvwMatchWorldStatsEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty; // "{tier}-{position}"

    [NotNull, Column("deaths_red")] public int DeathsRed { get; set; }
    [NotNull, Column("deaths_blue")] public int DeathsBlue { get; set; }
    [NotNull, Column("deaths_green")] public int DeathsGreen { get; set; }

    [NotNull, Column("kills_red")] public int KillsRed { get; set; }
    [NotNull, Column("kills_blue")] public int KillsBlue { get; set; }
    [NotNull, Column("kills_green")] public int KillsGreen { get; set; }
}

/// <summary>Kill/death stats for a single map within a <see cref="WvwMatchWorldStatsEntity"/>.</summary>
[Table("wvw_match_world_stats_maps")]
public class WvwMatchWorldStatsMapEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed(Name = "ux_wvw_match_world_stats_maps_stats_id_map_id", Order = 1, Unique = true)]
    [Column("world_stats_id")]
    public string WorldStatsId { get; set; } = string.Empty; // FK to WvwMatchWorldStatsEntity

    [NotNull]
    [Indexed(Name = "ux_wvw_match_world_stats_maps_stats_id_map_id", Order = 2, Unique = true)]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull, Indexed, Column("map_type")]
    public string MapType { get; set; } = string.Empty;

    [NotNull, Column("deaths_red")] public int DeathsRed { get; set; }
    [NotNull, Column("deaths_blue")] public int DeathsBlue { get; set; }
    [NotNull, Column("deaths_green")] public int DeathsGreen { get; set; }

    [NotNull, Column("kills_red")] public int KillsRed { get; set; }
    [NotNull, Column("kills_blue")] public int KillsBlue { get; set; }
    [NotNull, Column("kills_green")] public int KillsGreen { get; set; }
}
