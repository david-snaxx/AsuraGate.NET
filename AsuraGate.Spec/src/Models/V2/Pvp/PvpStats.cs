using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Pvp;

/// <summary>Represents account-wide PvP statistics, including rank progress and win/loss records across modes and professions.</summary>
public record PvpStats
{
    /// <summary>Current PvP rank number; resolvable to a <see cref="PvpRank"/>.</summary>
    [JsonPropertyName("pvp_rank")]
    public required int PvpRank { get; init; }

    /// <summary>Total rank points accumulated toward the next rank.</summary>
    [JsonPropertyName("pvp_rank_points")]
    public required int PvpRankPoints { get; init; }

    /// <summary>Number of times the rank has exceeded the maximum and restarted.</summary>
    [JsonPropertyName("pvp_rank_rollovers")]
    public required int PvpRankRollovers { get; init; }

    /// <summary>Aggregated win/loss statistics across all game modes.</summary>
    [JsonPropertyName("aggregate")]
    public required PvpWinLoss Aggregate { get; init; }

    /// <summary>Per-profession win/loss breakdown.</summary>
    [JsonPropertyName("professions")]
    public required PvpProfessionsWinLoss Professions { get; init; }

    /// <summary>Per-ladder win/loss breakdown.</summary>
    [JsonPropertyName("ladders")]
    public required PvpLadderWinLoss Ladders { get; init; }
}

/// <summary>Represents a win/loss outcome breakdown for <see cref="PvpStats"/> in a specific context.</summary>
public record PvpWinLoss
{
    /// <summary>Number of games won.</summary>
    [JsonPropertyName("wins")]
    public required int Wins { get; init; }

    /// <summary>Number of games lost.</summary>
    [JsonPropertyName("losses")]
    public required int Losses { get; init; }

    /// <summary>Number of games the player deserted (left early).</summary>
    [JsonPropertyName("desertions")]
    public required int Desertions { get; init; }

    /// <summary>Number of byes received (automatic wins with no opponent).</summary>
    [JsonPropertyName("byes")]
    public required int Byes { get; init; }

    /// <summary>Number of games forfeited.</summary>
    [JsonPropertyName("forfeits")]
    public required int Forfeits { get; init; }
}

/// <summary>Represents per-profession win/loss breakdowns within <see cref="PvpStats"/>.</summary>
public record PvpProfessionsWinLoss
{
    /// <summary>Win/loss record while playing Guardian; null if no games played.</summary>
    [JsonPropertyName("guardian")]
    public PvpWinLoss? Guardian { get; init; }

    /// <summary>Win/loss record while playing Revenant; null if no games played.</summary>
    [JsonPropertyName("revenant")]
    public PvpWinLoss? Revenant { get; init; }

    /// <summary>Win/loss record while playing Warrior; null if no games played.</summary>
    [JsonPropertyName("warrior")]
    public PvpWinLoss? Warrior { get; init; }

    /// <summary>Win/loss record while playing Engineer; null if no games played.</summary>
    [JsonPropertyName("engineer")]
    public PvpWinLoss? Engineer { get; init; }

    /// <summary>Win/loss record while playing Ranger; null if no games played.</summary>
    [JsonPropertyName("ranger")]
    public PvpWinLoss? Ranger { get; init; }

    /// <summary>Win/loss record while playing Thief; null if no games played.</summary>
    [JsonPropertyName("thief")]
    public PvpWinLoss? Thief { get; init; }

    /// <summary>Win/loss record while playing Elementalist; null if no games played.</summary>
    [JsonPropertyName("elementalist")]
    public PvpWinLoss? Elementalist { get; init; }

    /// <summary>Win/loss record while playing Mesmer; null if no games played.</summary>
    [JsonPropertyName("mesmer")]
    public PvpWinLoss? Mesmer { get; init; }

    /// <summary>Win/loss record while playing Necromancer; null if no games played.</summary>
    [JsonPropertyName("necromancer")]
    public PvpWinLoss? Necromancer { get; init; }
}

/// <summary>Represents per-ladder win/loss breakdowns within <see cref="PvpStats"/>.</summary>
public record PvpLadderWinLoss
{
    /// <summary>Win/loss record in unranked matches; null if no games played.</summary>
    [JsonPropertyName("unranked")]
    public PvpWinLoss? Unranked { get; init; }

    /// <summary>Win/loss record in ranked matches; null if no games played.</summary>
    [JsonPropertyName("ranked")]
    public PvpWinLoss? Ranked { get; init; }

    /// <summary>Win/loss record in 2v2 ranked matches; null if no games played.</summary>
    [JsonPropertyName("2v2ranked")]
    public PvpWinLoss? TwoVTwoRanked { get; init; }

    /// <summary>Win/loss record in 3v3 ranked matches; null if no games played.</summary>
    [JsonPropertyName("3v3ranked")]
    public PvpWinLoss? ThreeVThreeRanked { get; init; }

    /// <summary>Win/loss record in ranked Capture the Flag matches; null if no games played.</summary>
    [JsonPropertyName("ctfranked")]
    public PvpWinLoss? CtfRanked { get; init; }

    /// <summary>Win/loss record in solo arena rated matches; null if no games played.</summary>
    [JsonPropertyName("soloarenarated")]
    public PvpWinLoss? SoloArenaRated { get; init; }

    /// <summary>Win/loss record in team arena rated matches; null if no games played.</summary>
    [JsonPropertyName("teamarenarated")]
    public PvpWinLoss? TeamArenaRated { get; init; }
}
