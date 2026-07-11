using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Homestead.HomesteadGlyph"/>.
/// </summary>
[Table("homestead_glyphs")]
public class HomesteadGlyphEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("slot")]
    public string Slot { get; set; } = string.Empty;
}
