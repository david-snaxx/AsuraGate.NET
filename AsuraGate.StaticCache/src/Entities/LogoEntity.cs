using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Logo"/>.
/// </summary>
[Table("logos")]
public class LogoEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Column("url")]
    public string Url { get; set; } = string.Empty;
}
