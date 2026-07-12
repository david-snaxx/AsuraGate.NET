using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Pvp;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpHero"/>. <c>Stats</c> is a fixed 1:1
/// object, flattened onto this row.
/// </summary>
[Table("pvp_heroes")]
public class PvpHeroEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

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
    [Column("stats_offense")]
    public int StatsOffense { get; set; }

    [NotNull]
    [Column("stats_defense")]
    public int StatsDefense { get; set; }

    [NotNull]
    [Column("stats_speed")]
    public int StatsSpeed { get; set; }

    [NotNull]
    [Column("overlay")]
    public string Overlay { get; set; } = string.Empty;

    [NotNull]
    [Column("underlay")]
    public string Underlay { get; set; } = string.Empty;
}

/// <summary>A cosmetic skin available for a <see cref="PvpHeroEntity"/>.</summary>
[Table("pvp_hero_skins")]
public class PvpHeroSkinEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("pvp_hero_id")]
    public string PvpHeroId { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull]
    [Column("is_default")]
    public bool IsDefault { get; set; }
}

/// <summary>Item ID that can unlock a <see cref="PvpHeroSkinEntity"/>.</summary>
[Table("pvp_hero_skin_unlock_items")]
public class PvpHeroSkinUnlockItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("pvp_hero_skin_id")]
    public int PvpHeroSkinId { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}
