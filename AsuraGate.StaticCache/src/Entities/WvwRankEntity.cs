using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwRank"/>.
/// </summary>
[Table("wvw_ranks")]
public class WvwRankEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("title")]
    public string Title { get; set; } = string.Empty;

    [NotNull, Indexed, Column("min_rank")]
    public int MinRank { get; set; }
}
