using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpAmulet"/>.
/// </summary>
[Table("pvp_amulets")]
public class PvpAmuletEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>An attribute bonus granted by a <see cref="PvpAmuletEntity"/>.</summary>
[Table("pvp_amulet_attributes")]
public class PvpAmuletAttributeEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed(Name = "ux_pvp_amulet_attributes_amulet_id_attribute", Order = 1, Unique = true)]
    [Column("amulet_id")]
    public int AmuletId { get; set; } // FK to PvpAmuletEntity

    [NotNull]
    [Indexed(Name = "ux_pvp_amulet_attributes_amulet_id_attribute", Order = 2, Unique = true)]
    [Column("attribute")]
    public string Attribute { get; set; } = string.Empty;

    [NotNull, Column("value")]
    public int Value { get; set; }
}
