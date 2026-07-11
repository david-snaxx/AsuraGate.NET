using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpRank"/>.
/// </summary>
[Table("pvp_ranks")]
public class PvpRankEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("finisher_id")]
    public int FinisherId { get; set; } // FK to FinisherEntity

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Indexed, Column("min_rank")]
    public int MinRank { get; set; }

    [NotNull, Column("max_rank")]
    public int MaxRank { get; set; }
}

/// <summary>A level step within a <see cref="PvpRankEntity"/> tier.</summary>
[Table("pvp_rank_levels")]
public class PvpRankLevelEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("pvp_rank_id")]
    public int PvpRankId { get; set; } // FK to PvpRankEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("min_rank")]
    public int MinRank { get; set; }

    [NotNull, Column("max_rank")]
    public int MaxRank { get; set; }

    [NotNull, Column("points")]
    public int Points { get; set; }
}
