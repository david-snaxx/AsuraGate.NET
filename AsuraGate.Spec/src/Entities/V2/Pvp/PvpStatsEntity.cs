using SQLite;

namespace AsuraGate.Spec.Entities.V2.Pvp;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpStats"/> - one row per account
/// (account-wide singleton, no Id on the model at all). <c>Aggregate</c> is a fixed 1:1
/// <c>PvpWinLoss</c>, flattened here; <c>Professions</c> and <c>Ladders</c> are fixed sets of named
/// optional <c>PvpWinLoss</c> slots (not dictionaries, but the same shape), so they get a shared child
/// table keyed by slot name, same idea as <see cref="PvpSeasonLeaderboardConfigEntity"/>.
/// </summary>
[Table("pvp_stats")]
public class PvpStatsEntity
{
    [PrimaryKey]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("pvp_rank")]
    public int PvpRank { get; set; }

    [NotNull]
    [Column("pvp_rank_points")]
    public int PvpRankPoints { get; set; }

    [NotNull]
    [Column("pvp_rank_rollovers")]
    public int PvpRankRollovers { get; set; }

    [NotNull]
    [Column("aggregate_wins")]
    public int AggregateWins { get; set; }

    [NotNull]
    [Column("aggregate_losses")]
    public int AggregateLosses { get; set; }

    [NotNull]
    [Column("aggregate_desertions")]
    public int AggregateDesertions { get; set; }

    [NotNull]
    [Column("aggregate_byes")]
    public int AggregateByes { get; set; }

    [NotNull]
    [Column("aggregate_forfeits")]
    public int AggregateForfeits { get; set; }
}

/// <summary>
/// A win/loss record for one profession or ladder slot on a <see cref="PvpStatsEntity"/>.
/// <see cref="Category"/> is "profession" or "ladder"; <see cref="Slot"/> is the profession/ladder name.
/// Only slots with a non-null record on the model get a row here.
/// </summary>
[Table("pvp_stats_win_loss_records")]
public class PvpStatsWinLossRecordEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("category")]
    public string Category { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;

    [NotNull]
    [Column("wins")]
    public int Wins { get; set; }

    [NotNull]
    [Column("losses")]
    public int Losses { get; set; }

    [NotNull]
    [Column("desertions")]
    public int Desertions { get; set; }

    [NotNull]
    [Column("byes")]
    public int Byes { get; set; }

    [NotNull]
    [Column("forfeits")]
    public int Forfeits { get; set; }
}
