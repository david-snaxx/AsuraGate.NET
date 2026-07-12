using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Emote"/>.
/// </summary>
[Table("emotes")]
public class EmoteEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;
}

/// <summary>Chat command that triggers an <see cref="EmoteEntity"/>.</summary>
[Table("emote_commands")]
public class EmoteCommandEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("emote_id")]
    public string EmoteId { get; set; } = string.Empty;

    [NotNull]
    [Column("command")]
    public string Command { get; set; } = string.Empty;
}

/// <summary>Item ID that can unlock an <see cref="EmoteEntity"/>.</summary>
[Table("emote_unlock_items")]
public class EmoteUnlockItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("emote_id")]
    public string EmoteId { get; set; } = string.Empty;

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}
