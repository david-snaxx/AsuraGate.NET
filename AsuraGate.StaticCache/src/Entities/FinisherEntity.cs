using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Finisher"/>.
/// </summary>
[Table("finishers")]
public class FinisherEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("unlock_details")]
    public string UnlockDetails { get; set; } = string.Empty;

    [NotNull, Indexed, Column("order")]
    public int Order { get; set; }

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>Items that unlock a <see cref="FinisherEntity"/>.</summary>
[Table("finisher_unlock_items")]
public class FinisherUnlockItemEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("finisher_id")]
    public int FinisherId { get; set; } // FK to FinisherEntity

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity
}
