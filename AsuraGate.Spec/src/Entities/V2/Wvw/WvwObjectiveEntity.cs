using SQLite;

namespace AsuraGate.Spec.Entities.V2.Wvw;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwObjective"/>. <c>Coord</c> and
/// <c>LabelCoord</c> are fixed-shape tuples, flattened into columns.
/// </summary>
[Table("wvw_objectives")]
public class WvwObjectiveEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("sector_id")]
    public int SectorId { get; set; }

    [NotNull]
    [Indexed]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull]
    [Column("map_type")]
    public string MapType { get; set; } = string.Empty;

    [NotNull]
    [Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull]
    [Column("coord_y")]
    public double CoordY { get; set; }

    [NotNull]
    [Column("coord_z")]
    public double CoordZ { get; set; }

    [NotNull]
    [Column("label_coord_x")]
    public double LabelCoordX { get; set; }

    [NotNull]
    [Column("label_coord_y")]
    public double LabelCoordY { get; set; }

    [Column("marker")]
    public string? Marker { get; set; }

    [NotNull]
    [Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;

    [Column("upgrade_id")]
    public int? UpgradeId { get; set; }
}
