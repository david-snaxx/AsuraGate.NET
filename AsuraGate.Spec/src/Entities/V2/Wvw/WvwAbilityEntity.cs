using SQLite;

namespace AsuraGate.Spec.Entities.V2.Wvw;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwAbility"/>.
/// </summary>
[Table("wvw_abilities")]
public class WvwAbilityEntity
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
}

/// <summary>A trainable rank level within a <see cref="WvwAbilityEntity"/>.</summary>
[Table("wvw_ability_ranks")]
public class WvwAbilityRankEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("wvw_ability_id")]
    public int WvwAbilityId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("cost")]
    public int Cost { get; set; }

    [NotNull]
    [Column("effect")]
    public string Effect { get; set; } = string.Empty;
}
