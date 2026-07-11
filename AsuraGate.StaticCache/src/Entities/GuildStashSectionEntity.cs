using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildStashSection"/>. The model has no id (a
/// stash tab is identified by its position in the guild's stash array), so this uses a DB-assigned id and
/// records that position in <see cref="OrderIndex"/>.
/// </summary>
[Table("guild_stash_sections")]
public class GuildStashSectionEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull, Indexed, Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("upgrade_id")]
    public int UpgradeId { get; set; } // FK to GuildUpgradeEntity

    [NotNull, Column("size")]
    public int Size { get; set; }

    [NotNull, Column("coins")]
    public int Coins { get; set; }

    [NotNull, Column("note")]
    public string Note { get; set; } = string.Empty;
}

/// <summary>A single inventory slot within a <see cref="GuildStashSectionEntity"/>; a null <see cref="ItemId"/> means the slot is empty.</summary>
[Table("guild_stash_slots")]
public class GuildStashSlotEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_stash_section_id")]
    public int GuildStashSectionId { get; set; } // FK to GuildStashSectionEntity

    [NotNull, Column("slot_index")]
    public int SlotIndex { get; set; }

    [Indexed, Column("item_id")]
    public int? ItemId { get; set; } // FK to ItemEntity; null if the slot is empty

    [Column("count")]
    public int? Count { get; set; }
}
