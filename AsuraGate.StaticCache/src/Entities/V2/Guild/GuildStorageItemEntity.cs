using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildStorageItem"/>. Guild-scoped, no
/// GuildId on the model - callers must supply it.
/// </summary>
[Table("guild_storage_items")]
public class GuildStorageItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }
}
