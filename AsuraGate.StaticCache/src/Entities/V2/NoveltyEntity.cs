using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Novelty"/>.
/// </summary>
[Table("novelties")]
public class NoveltyEntity
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
    [Indexed]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;
}

/// <summary>Item ID that can unlock a <see cref="NoveltyEntity"/>.</summary>
[Table("novelty_unlock_items")]
public class NoveltyUnlockItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("novelty_id")]
    public int NoveltyId { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}
