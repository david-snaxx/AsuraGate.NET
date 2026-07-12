using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Mini"/>.
/// </summary>
[Table("minis")]
public class MiniEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("unlock")]
    public string? Unlock { get; set; }

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull]
    [Column("order")]
    public int Order { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }
}
