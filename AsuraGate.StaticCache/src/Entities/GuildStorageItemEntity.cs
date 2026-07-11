using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildStorageItem"/>.
/// </summary>
[Table("guild_storage_items")]
public class GuildStorageItemEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_guild_storage_items_guild_id_item_id", Order = 1, Unique = true)]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull]
    [Indexed(Name = "ux_guild_storage_items_guild_id_item_id", Order = 2, Unique = true)]
    [Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Column("count")]
    public int Count { get; set; }
}
