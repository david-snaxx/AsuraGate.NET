using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildTreasuryItem"/>.
/// </summary>
[Table("guild_treasury_items")]
public class GuildTreasuryItemEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_guild_treasury_items_guild_id_item_id", Order = 1, Unique = true)]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull]
    [Indexed(Name = "ux_guild_treasury_items_guild_id_item_id", Order = 2, Unique = true)]
    [Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Column("count")]
    public int Count { get; set; }
}

/// <summary>A guild upgrade that needs a <see cref="GuildTreasuryItemEntity"/>.</summary>
[Table("guild_treasury_item_needs")]
public class GuildTreasuryItemNeedEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_treasury_item_id")]
    public int GuildTreasuryItemId { get; set; } // FK to GuildTreasuryItemEntity

    [NotNull, Indexed, Column("upgrade_id")]
    public int UpgradeId { get; set; } // FK to GuildUpgradeEntity

    [NotNull, Column("count")]
    public int Count { get; set; }
}
