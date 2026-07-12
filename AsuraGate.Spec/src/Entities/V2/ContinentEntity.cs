using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Continent"/>. The fixed [width,height]
/// <c>ContinentDims</c> pair is flattened into two columns rather than a child table, since it's a
/// tuple, not a variable-length list.
/// </summary>
[Table("continents")]
public class ContinentEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("continent_dims_width")]
    public int ContinentDimsWidth { get; set; }

    [NotNull]
    [Column("continent_dims_height")]
    public int ContinentDimsHeight { get; set; }

    [NotNull]
    [Column("min_zoom")]
    public int MinZoom { get; set; }

    [NotNull]
    [Column("max_zoom")]
    public int MaxZoom { get; set; }
}

/// <summary>Floor index belonging to a <see cref="ContinentEntity"/>.</summary>
[Table("continent_floor_ids")]
public class ContinentFloorIdEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("continent_id")]
    public int ContinentId { get; set; }

    [NotNull]
    [Column("floor_id")]
    public int FloorId { get; set; }
}
