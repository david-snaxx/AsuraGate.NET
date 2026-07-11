using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.JadeBot"/>.
/// </summary>
[Table("jade_bots")]
public class JadeBotEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Indexed, Column("unlock_item")]
    public int UnlockItem { get; set; } // FK to ItemEntity
}
