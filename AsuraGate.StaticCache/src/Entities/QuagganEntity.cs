using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Quaggan"/>.
/// </summary>
[Table("quaggans")]
public class QuagganEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Column("url")]
    public string Url { get; set; } = string.Empty;
}
