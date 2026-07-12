using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Glider"/>.
/// </summary>
[Table("gliders")]
public class GliderEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull]
    [Column("order")]
    public int Order { get; set; }
}

/// <summary>Item ID that can unlock a <see cref="GliderEntity"/>.</summary>
[Table("glider_unlock_items")]
public class GliderUnlockItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("glider_id")]
    public int GliderId { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}

/// <summary>Default dye color applied to a <see cref="GliderEntity"/>; order matches the dye channel index.</summary>
[Table("glider_default_dyes")]
public class GliderDefaultDyeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("glider_id")]
    public int GliderId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("dye_id")]
    public int DyeId { get; set; }
}
