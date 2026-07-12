using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Wvw;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwRank"/>.
/// </summary>
[Table("wvw_ranks")]
public class WvwRankEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [NotNull]
    [Column("min_rank")]
    public int MinRank { get; set; }
}
