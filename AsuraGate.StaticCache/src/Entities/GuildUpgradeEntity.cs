using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildUpgrade"/>.
/// </summary>
[Table("guild_upgrades")]
public class GuildUpgradeEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Column("build_time")]
    public int BuildTime { get; set; }

    [NotNull, Indexed, Column("required_level")]
    public int RequiredLevel { get; set; }

    [NotNull, Column("experience")]
    public int Experience { get; set; }

    [Column("bag_max_items")]
    public int? BagMaxItems { get; set; }

    [Column("bag_max_coins")]
    public int? BagMaxCoins { get; set; }
}

/// <summary>A guild upgrade that must be built before a <see cref="GuildUpgradeEntity"/> becomes available.</summary>
[Table("guild_upgrade_prerequisites")]
public class GuildUpgradePrerequisiteEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_upgrade_id")]
    public int GuildUpgradeId { get; set; } // FK to GuildUpgradeEntity

    [NotNull, Indexed, Column("prerequisite_upgrade_id")]
    public int PrerequisiteUpgradeId { get; set; } // FK to GuildUpgradeEntity
}

/// <summary>A resource cost required to build a <see cref="GuildUpgradeEntity"/>.</summary>
[Table("guild_upgrade_costs")]
public class GuildUpgradeCostEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_upgrade_id")]
    public int GuildUpgradeId { get; set; } // FK to GuildUpgradeEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("cost_type")]
    public string CostType { get; set; } = string.Empty; // "Item", "Collectible", "Currency"

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("count")]
    public int Count { get; set; }

    [Indexed, Column("item_id")]
    public int? ItemId { get; set; } // FK to ItemEntity
}
