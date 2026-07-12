using AsuraGate.Spec.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Spec.Mappers.V2.Pvp;

public static class PvpStatsMapper
{
    public static PvpStatsEntity ToEntity(string accountId, PvpStats stats) => new PvpStatsEntity()
    {
        AccountId = accountId,
        PvpRank = stats.PvpRank,
        PvpRankPoints = stats.PvpRankPoints,
        PvpRankRollovers = stats.PvpRankRollovers,
        AggregateWins = stats.Aggregate.Wins,
        AggregateLosses = stats.Aggregate.Losses,
        AggregateDesertions = stats.Aggregate.Desertions,
        AggregateByes = stats.Aggregate.Byes,
        AggregateForfeits = stats.Aggregate.Forfeits
    };

    private static PvpStatsWinLossRecordEntity? ToRecordEntity(string accountId, string category, string slot, PvpWinLoss? record)
    {
        if (record is null)
        {
            return null;
        }

        return new PvpStatsWinLossRecordEntity()
        {
            AccountId = accountId,
            Category = category,
            Slot = slot,
            Wins = record.Wins,
            Losses = record.Losses,
            Desertions = record.Desertions,
            Byes = record.Byes,
            Forfeits = record.Forfeits
        };
    }

    public static IEnumerable<PvpStatsWinLossRecordEntity> ToRecordEntities(string accountId, PvpStats stats)
    {
        var professions = new (string Slot, PvpWinLoss? Record)[]
        {
            ("guardian", stats.Professions.Guardian),
            ("revenant", stats.Professions.Revenant),
            ("warrior", stats.Professions.Warrior),
            ("engineer", stats.Professions.Engineer),
            ("ranger", stats.Professions.Ranger),
            ("thief", stats.Professions.Thief),
            ("elementalist", stats.Professions.Elementalist),
            ("mesmer", stats.Professions.Mesmer),
            ("necromancer", stats.Professions.Necromancer)
        };

        var ladders = new (string Slot, PvpWinLoss? Record)[]
        {
            ("unranked", stats.Ladders.Unranked),
            ("ranked", stats.Ladders.Ranked),
            ("2v2ranked", stats.Ladders.TwoVTwoRanked),
            ("3v3ranked", stats.Ladders.ThreeVThreeRanked),
            ("ctfranked", stats.Ladders.CtfRanked),
            ("soloarenarated", stats.Ladders.SoloArenaRated),
            ("teamarenarated", stats.Ladders.TeamArenaRated)
        };

        var professionEntities = professions.Select(p => ToRecordEntity(accountId, "profession", p.Slot, p.Record));
        var ladderEntities = ladders.Select(l => ToRecordEntity(accountId, "ladder", l.Slot, l.Record));

        return professionEntities.Concat(ladderEntities).Where(entity => entity is not null)!;
    }

    public static PvpStats ToModel(PvpStatsEntity entity, IEnumerable<PvpStatsWinLossRecordEntity> recordEntities)
    {
        var records = recordEntities.ToList();

        PvpWinLoss? Find(string category, string slot)
        {
            var record = records.FirstOrDefault(r => r.Category == category && r.Slot == slot);
            return record is null ? null : new PvpWinLoss()
            {
                Wins = record.Wins,
                Losses = record.Losses,
                Desertions = record.Desertions,
                Byes = record.Byes,
                Forfeits = record.Forfeits
            };
        }

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
                Forfeits = entity.AggregateForfeits
            },
            Professions = new PvpProfessionsWinLoss()
            {
                Guardian = Find("profession", "guardian"),
                Revenant = Find("profession", "revenant"),
                Warrior = Find("profession", "warrior"),
                Engineer = Find("profession", "engineer"),
                Ranger = Find("profession", "ranger"),
                Thief = Find("profession", "thief"),
                Elementalist = Find("profession", "elementalist"),
                Mesmer = Find("profession", "mesmer"),
                Necromancer = Find("profession", "necromancer")
            },
            Ladders = new PvpLadderWinLoss()
            {
                Unranked = Find("ladder", "unranked"),
                Ranked = Find("ladder", "ranked"),
                TwoVTwoRanked = Find("ladder", "2v2ranked"),
                ThreeVThreeRanked = Find("ladder", "3v3ranked"),
                CtfRanked = Find("ladder", "ctfranked"),
                SoloArenaRated = Find("ladder", "soloarenarated"),
                TeamArenaRated = Find("ladder", "teamarenarated")
            }
        };
    }
}
