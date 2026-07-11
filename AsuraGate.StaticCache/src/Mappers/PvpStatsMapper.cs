using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="PvpStats"/> to <see cref="PvpStatsEntity"/>. <see cref="PvpProfessionsWinLoss"/> and
/// <see cref="PvpLadderWinLoss"/> are fixed sets of nullable named fields rather than real dictionaries, so
/// they're mapped explicitly by name into rows, one per profession/ladder that has been played.
/// </summary>
public static class PvpStatsMapper
{
    public static PvpStatsEntity ToEntity(PvpStats stats) => new PvpStatsEntity()
    {
        PvpRank = stats.PvpRank,
        PvpRankPoints = stats.PvpRankPoints,
        PvpRankRollovers = stats.PvpRankRollovers,
        AggregateWins = stats.Aggregate.Wins,
        AggregateLosses = stats.Aggregate.Losses,
        AggregateDesertions = stats.Aggregate.Desertions,
        AggregateByes = stats.Aggregate.Byes,
        AggregateForfeits = stats.Aggregate.Forfeits,
    };

    private static PvpStatsProfessionEntity? ToProfessionEntity(string profession, PvpWinLoss? winLoss) =>
        winLoss is null ? null : new PvpStatsProfessionEntity()
        {
            Profession = profession,
            Wins = winLoss.Wins,
            Losses = winLoss.Losses,
            Desertions = winLoss.Desertions,
            Byes = winLoss.Byes,
            Forfeits = winLoss.Forfeits,
        };

    public static IReadOnlyList<PvpStatsProfessionEntity> ToProfessionEntities(PvpStats stats) => new[]
    {
        ToProfessionEntity("guardian", stats.Professions.Guardian),
        ToProfessionEntity("revenant", stats.Professions.Revenant),
        ToProfessionEntity("warrior", stats.Professions.Warrior),
        ToProfessionEntity("engineer", stats.Professions.Engineer),
        ToProfessionEntity("ranger", stats.Professions.Ranger),
        ToProfessionEntity("thief", stats.Professions.Thief),
        ToProfessionEntity("elementalist", stats.Professions.Elementalist),
        ToProfessionEntity("mesmer", stats.Professions.Mesmer),
        ToProfessionEntity("necromancer", stats.Professions.Necromancer),
    }.Where(e => e is not null).Select(e => e!).ToList();

    private static PvpStatsLadderEntity? ToLadderEntity(string ladder, PvpWinLoss? winLoss) =>
        winLoss is null ? null : new PvpStatsLadderEntity()
        {
            Ladder = ladder,
            Wins = winLoss.Wins,
            Losses = winLoss.Losses,
            Desertions = winLoss.Desertions,
            Byes = winLoss.Byes,
            Forfeits = winLoss.Forfeits,
        };

    public static IReadOnlyList<PvpStatsLadderEntity> ToLadderEntities(PvpStats stats) => new[]
    {
        ToLadderEntity("unranked", stats.Ladders.Unranked),
        ToLadderEntity("ranked", stats.Ladders.Ranked),
        ToLadderEntity("2v2ranked", stats.Ladders.TwoVTwoRanked),
        ToLadderEntity("3v3ranked", stats.Ladders.ThreeVThreeRanked),
        ToLadderEntity("ctfranked", stats.Ladders.CtfRanked),
        ToLadderEntity("soloarenarated", stats.Ladders.SoloArenaRated),
        ToLadderEntity("teamarenarated", stats.Ladders.TeamArenaRated),
    }.Where(e => e is not null).Select(e => e!).ToList();

    private static PvpWinLoss ToWinLossModel(PvpStatsProfessionEntity entity) => new PvpWinLoss()
    {
        Wins = entity.Wins,
        Losses = entity.Losses,
        Desertions = entity.Desertions,
        Byes = entity.Byes,
        Forfeits = entity.Forfeits,
    };

    private static PvpWinLoss ToWinLossModel(PvpStatsLadderEntity entity) => new PvpWinLoss()
    {
        Wins = entity.Wins,
        Losses = entity.Losses,
        Desertions = entity.Desertions,
        Byes = entity.Byes,
        Forfeits = entity.Forfeits,
    };

    public static PvpStats ToModel(PvpStatsEntity entity, IEnumerable<PvpStatsProfessionEntity> professions, IEnumerable<PvpStatsLadderEntity> ladders)
    {
        var professionMap = professions.ToDictionary(p => p.Profession);
        var ladderMap = ladders.ToDictionary(l => l.Ladder);

        PvpWinLoss? Profession(string key) => professionMap.TryGetValue(key, out var p) ? ToWinLossModel(p) : null;
        PvpWinLoss? Ladder(string key) => ladderMap.TryGetValue(key, out var l) ? ToWinLossModel(l) : null;

        return new PvpStats()
        {
            PvpRank = entity.PvpRank,
            PvpRankPoints = entity.PvpRankPoints,
            PvpRankRollovers = entity.PvpRankRollovers,
            Aggregate = new PvpWinLoss()
            {
                Wins = entity.AggregateWins,
                Losses = entity.AggregateLosses,
                Desertions = entity.AggregateDesertions,
                Byes = entity.AggregateByes,
                Forfeits = entity.AggregateForfeits,
            },
            Professions = new PvpProfessionsWinLoss()
            {
                Guardian = Profession("guardian"),
                Revenant = Profession("revenant"),
                Warrior = Profession("warrior"),
                Engineer = Profession("engineer"),
                Ranger = Profession("ranger"),
                Thief = Profession("thief"),
                Elementalist = Profession("elementalist"),
                Mesmer = Profession("mesmer"),
                Necromancer = Profession("necromancer"),
            },
            Ladders = new PvpLadderWinLoss()
            {
                Unranked = Ladder("unranked"),
                Ranked = Ladder("ranked"),
                TwoVTwoRanked = Ladder("2v2ranked"),
                ThreeVThreeRanked = Ladder("3v3ranked"),
                CtfRanked = Ladder("ctfranked"),
                SoloArenaRated = Ladder("soloarenarated"),
                TeamArenaRated = Ladder("teamarenarated"),
            },
        };
    }
}
