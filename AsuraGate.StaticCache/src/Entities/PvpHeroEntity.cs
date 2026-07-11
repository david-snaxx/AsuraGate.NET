using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpHero"/>.
/// </summary>
[Table("pvp_heroes")]
public class PvpHeroEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull, Column("stats_offense")] public int StatsOffense { get; set; }
    [NotNull, Column("stats_defense")] public int StatsDefense { get; set; }
    [NotNull, Column("stats_speed")] public int StatsSpeed { get; set; }

    [NotNull, Column("overlay")]
    public string Overlay { get; set; } = string.Empty;

    [NotNull, Column("underlay")]
    public string Underlay { get; set; } = string.Empty;
}

/// <summary>A cosmetic skin available for a <see cref="PvpHeroEntity"/>.</summary>
[Table("pvp_hero_skins")]
public class PvpHeroSkinEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("hero_id")]
    public string HeroId { get; set; } = string.Empty; // FK to PvpHeroEntity

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Indexed, Column("is_default")]
    public bool IsDefault { get; set; }
}

/// <summary>An item that unlocks a <see cref="PvpHeroSkinEntity"/>.</summary>
[Table("pvp_hero_skin_unlock_items")]
public class PvpHeroSkinUnlockItemEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("pvp_hero_skin_id")]
    public int PvpHeroSkinId { get; set; } // FK to PvpHeroSkinEntity

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity
}
