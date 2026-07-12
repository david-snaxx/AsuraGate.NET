using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.LegendaryArmoryItem"/>.
/// </summary>
[Table("legendary_armory_items")]
public class LegendaryArmoryItemEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("max_count")]
    public int MaxCount { get; set; }
}
