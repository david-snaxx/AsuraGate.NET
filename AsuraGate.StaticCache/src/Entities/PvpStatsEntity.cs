using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpStats"/>. The model is a single account-wide
/// snapshot with no id, so this holds one row keyed on a fixed id of 1.
/// </summary>
[Table("pvp_stats")]
public class PvpStatsEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; } = 1;

    [NotNull, Column("pvp_rank")] public int PvpRank { get; set; }
    [NotNull, Column("pvp_rank_points")] public int PvpRankPoints { get; set; }
    [NotNull, Column("pvp_rank_rollovers")] public int PvpRankRollovers { get; set; }

    [NotNull, Column("aggregate_wins")] public int AggregateWins { get; set; }
    [NotNull, Column("aggregate_losses")] public int AggregateLosses { get; set; }
    [NotNull, Column("aggregate_desertions")] public int AggregateDesertions { get; set; }
    [NotNull, Column("aggregate_byes")] public int AggregateByes { get; set; }
    [NotNull, Column("aggregate_forfeits")] public int AggregateForfeits { get; set; }
}

/// <summary>
/// A per-profession win/loss breakdown within <see cref="PvpStatsEntity"/>; only professions with games played
/// get a row (the model represents "no games played" as a null field per profession).
/// </summary>
[Table("pvp_stats_professions")]
public class PvpStatsProfessionEntity
{
    [PrimaryKey, Column("profession")]
    public string Profession { get; set; } = string.Empty;

    [NotNull, Column("wins")] public int Wins { get; set; }
    [NotNull, Column("losses")] public int Losses { get; set; }
    [NotNull, Column("desertions")] public int Desertions { get; set; }
    [NotNull, Column("byes")] public int Byes { get; set; }
    [NotNull, Column("forfeits")] public int Forfeits { get; set; }
}

/// <summary>
/// A per-ladder win/loss breakdown within <see cref="PvpStatsEntity"/>; only ladders with games played get a row.
/// </summary>
[Table("pvp_stats_ladders")]
public class PvpStatsLadderEntity
{
    [PrimaryKey, Column("ladder")]
    public string Ladder { get; set; } = string.Empty; // "unranked", "ranked", "2v2ranked", "3v3ranked", "ctfranked", "soloarenarated", "teamarenarated"

    [NotNull, Column("wins")] public int Wins { get; set; }
    [NotNull, Column("losses")] public int Losses { get; set; }
    [NotNull, Column("desertions")] public int Desertions { get; set; }
    [NotNull, Column("byes")] public int Byes { get; set; }
    [NotNull, Column("forfeits")] public int Forfeits { get; set; }
}
