using SQLite;

namespace AsuraGate.Spec.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildStashSection"/>. The model has no ID
/// of its own - a guild's stash sections are just a plain array - so this row's identity within a guild
/// is its array position, carried as <see cref="OrderIndex"/>; callers supply <see cref="GuildId"/>.
/// </summary>
[Table("guild_stash_sections")]
public class GuildStashSectionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("upgrade_id")]
    public int UpgradeId { get; set; }

    [NotNull]
    [Column("size")]
    public int Size { get; set; }

    [NotNull]
    [Column("coins")]
    public int Coins { get; set; }

    [NotNull]
    [Column("note")]
    public string Note { get; set; } = string.Empty;
}

/// <summary>
/// A slot within a <see cref="GuildStashSectionEntity"/>'s inventory. A null <see cref="ItemId"/> means
/// the model's slot entry was null (empty slot) - the row still exists so the slot's position is
/// preserved. Carries (GuildId, SectionOrderIndex) down rather than the section's surrogate id.
/// </summary>
[Table("guild_stash_items")]
public class GuildStashItemEntity
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
    [Column("section_order_index")]
    public int SectionOrderIndex { get; set; }

    [NotNull]
    [Column("slot_index")]
    public int SlotIndex { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }

    [Column("count")]
    public int? Count { get; set; }
}
