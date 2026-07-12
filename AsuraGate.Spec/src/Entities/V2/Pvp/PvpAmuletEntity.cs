using SQLite;

namespace AsuraGate.Spec.Entities.V2.Pvp;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpAmulet"/>.
/// </summary>
[Table("pvp_amulets")]
public class PvpAmuletEntity
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

/// <summary>An attribute value (dictionary entry) on a <see cref="PvpAmuletEntity"/>.</summary>
[Table("pvp_amulet_attributes")]
public class PvpAmuletAttributeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("pvp_amulet_id")]
    public int PvpAmuletId { get; set; }

    [NotNull]
    [Column("attribute")]
    public string Attribute { get; set; } = string.Empty;

    [NotNull]
    [Column("value")]
    public int Value { get; set; }
}
