using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.ItemStat"/>.
/// </summary>
[Table("item_stats")]
public class ItemStatEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}

/// <summary>Single attribute bonus within an <see cref="ItemStatEntity"/> stat set.</summary>
[Table("item_stat_attributes")]
public class ItemStatAttributeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_stat_id")]
    public int ItemStatId { get; set; }

    [NotNull]
    [Column("attribute")]
    public string Attribute { get; set; } = string.Empty;

    [NotNull]
    [Column("multiplier")]
    public double Multiplier { get; set; }

    [NotNull]
    [Column("value")]
    public int Value { get; set; }
}
