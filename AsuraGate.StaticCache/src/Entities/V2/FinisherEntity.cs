using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Finisher"/>.
/// </summary>
[Table("finishers")]
public class FinisherEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("unlock_details")]
    public string UnlockDetails { get; set; } = string.Empty;

    [NotNull]
    [Column("order")]
    public int Order { get; set; }

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>Item ID that can unlock a <see cref="FinisherEntity"/>.</summary>
[Table("finisher_unlock_items")]
public class FinisherUnlockItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("finisher_id")]
    public int FinisherId { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}
