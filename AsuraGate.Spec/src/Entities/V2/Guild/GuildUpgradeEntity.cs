using SQLite;

namespace AsuraGate.Spec.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildUpgrade"/>. Unlike most Guild/*
/// models, this is a static catalog of all possible upgrades in the game - no GuildId needed.
/// </summary>
[Table("guild_upgrades")]
public class GuildUpgradeEntity
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
    [Indexed]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull]
    [Column("build_time")]
    public int BuildTime { get; set; }

    [NotNull]
    [Column("required_level")]
    public int RequiredLevel { get; set; }

    [NotNull]
    [Column("experience")]
    public int Experience { get; set; }

    [Column("bag_max_items")]
    public int? BagMaxItems { get; set; }

    [Column("bag_max_coins")]
    public int? BagMaxCoins { get; set; }
}

/// <summary>Prerequisite upgrade ID for a <see cref="GuildUpgradeEntity"/>.</summary>
[Table("guild_upgrade_prerequisites")]
public class GuildUpgradePrerequisiteEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_upgrade_id")]
    public int GuildUpgradeId { get; set; }

    [NotNull]
    [Column("prerequisite_upgrade_id")]
    public int PrerequisiteUpgradeId { get; set; }
}

/// <summary>Resource cost required to build a <see cref="GuildUpgradeEntity"/>.</summary>
[Table("guild_upgrade_costs")]
public class GuildUpgradeCostEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_upgrade_id")]
    public int GuildUpgradeId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("count")]
    public int Count { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }
}
