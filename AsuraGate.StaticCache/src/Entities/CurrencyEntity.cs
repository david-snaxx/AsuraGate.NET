using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Currency"/>.
/// </summary>
[Table("currencies")]
public class CurrencyEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Indexed, Column("order")]
    public int Order { get; set; }
}
