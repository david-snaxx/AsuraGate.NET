using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// Many-to-many join between <see cref="DyeEntity"/> and its category labels (e.g. "Blues", "Vibrant").
/// The (DyeId, Category) pair is unique so a re-import cannot duplicate a tag, and Category is indexed
/// on its own so "find all dyes tagged X" doesn't need to scan.
/// </summary>
[Table("dye_categories")]
public class DyeCategoryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed(Name = "ux_dye_categories_dye_id_category", Order = 1, Unique = true), Column("dye_id")]
    public int DyeId { get; set; }

    [NotNull]
    [Indexed(Name = "ux_dye_categories_dye_id_category", Order = 2, Unique = true)]
    [Indexed(Name = "ix_dye_categories_category")]
    [Column("category")]
    public string Category { get; set; } = string.Empty;
}
