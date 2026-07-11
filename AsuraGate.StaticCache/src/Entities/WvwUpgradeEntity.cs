using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwUpgrade"/>.
/// </summary>
[Table("wvw_upgrades")]
public class WvwUpgradeEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; } // FK to WvwObjectiveEntity
}

/// <summary>A tier within a <see cref="WvwUpgradeEntity"/> progression track.</summary>
[Table("wvw_upgrade_tiers")]
public class WvwUpgradeTierEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("wvw_upgrade_id")]
    public int WvwUpgradeId { get; set; } // FK to WvwUpgradeEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("yaks_required")]
    public int YaksRequired { get; set; }
}

/// <summary>A single upgrade unlocked within a <see cref="WvwUpgradeTierEntity"/>.</summary>
[Table("wvw_upgrade_items")]
public class WvwUpgradeItemEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("wvw_upgrade_tier_id")]
    public int WvwUpgradeTierId { get; set; } // FK to WvwUpgradeTierEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;
}
