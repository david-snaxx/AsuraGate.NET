using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildTreasuryItem"/>. Guild-scoped, no
/// GuildId on the model - callers must supply it.
/// </summary>
[Table("guild_treasury_items")]
public class GuildTreasuryItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }
}

/// <summary>An upgrade that still needs a <see cref="GuildTreasuryItemEntity"/>.</summary>
[Table("guild_treasury_item_needs")]
public class GuildTreasuryItemNeedEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("upgrade_id")]
    public int UpgradeId { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }
}
