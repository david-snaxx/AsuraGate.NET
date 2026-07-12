using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Skiff"/>.
/// </summary>
[Table("skiffs")]
public class SkiffEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>
/// Dye slot within a <see cref="SkiffEntity"/>. The default color/material is flattened onto this row
/// (nullable) rather than a further child table, since a slot has at most one default configuration.
/// </summary>
[Table("skiff_dye_slots")]
public class SkiffDyeSlotEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skiff_id")]
    public int SkiffId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("default_color_id")]
    public int? DefaultColorId { get; set; }

    [Column("default_material")]
    public string? DefaultMaterial { get; set; }
}
