using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Outfit"/>.
/// </summary>
[Table("outfits")]
public class OutfitEntity
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

/// <summary>Item ID that can unlock an <see cref="OutfitEntity"/>.</summary>
[Table("outfit_unlock_items")]
public class OutfitUnlockItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("outfit_id")]
    public int OutfitId { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}
