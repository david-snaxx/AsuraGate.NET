using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Skiff"/>.
/// </summary>
[Table("skiffs")]
public class SkiffEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>A dye slot on a <see cref="SkiffEntity"/> skin.</summary>
[Table("skiff_dye_slots")]
public class SkiffDyeSlotEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skiff_id")]
    public int SkiffId { get; set; } // FK to SkiffEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [Indexed, Column("default_color_id")]
    public int? DefaultColorId { get; set; } // FK to DyeEntity

    [Column("default_material")]
    public string? DefaultMaterial { get; set; }
}
