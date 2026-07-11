using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Emote"/>.
/// </summary>
[Table("emotes")]
public class EmoteEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;
}

/// <summary>Chat commands that trigger an <see cref="EmoteEntity"/> (e.g. "/beckon").</summary>
[Table("emote_commands")]
public class EmoteCommandEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("emote_id")]
    public string EmoteId { get; set; } = string.Empty; // FK to EmoteEntity

    [NotNull, Indexed, Column("command")]
    public string Command { get; set; } = string.Empty;
}

/// <summary>Items that unlock an <see cref="EmoteEntity"/>.</summary>
[Table("emote_unlock_items")]
public class EmoteUnlockItemEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("emote_id")]
    public string EmoteId { get; set; } = string.Empty; // FK to EmoteEntity

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity
}
