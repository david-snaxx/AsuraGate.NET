using AsuraGate.Spec.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Spec.Mappers.V2.Pvp;

public static class PvpRankMapper
{
    public static PvpRankEntity ToPvpRankEntity(PvpRank rank) => new PvpRankEntity()
    {
        Id = rank.Id,
        FinisherId = rank.FinisherId,
        Name = rank.Name,
        Icon = rank.Icon,
        MinRank = rank.MinRank,
        MaxRank = rank.MaxRank
    };

    public static IEnumerable<PvpRankLevelEntity> ToLevelEntities(PvpRank rank) =>
        rank.Levels.Select((level, index) => new PvpRankLevelEntity()
        {
            PvpRankId = rank.Id,
            OrderIndex = index,
            MinRank = level.MinRank,
            MaxRank = level.MaxRank,
            Points = level.Points
        });

    public static PvpRank ToModel(PvpRankEntity entity, IEnumerable<PvpRankLevelEntity> levelEntities) => new PvpRank()
    {
        Id = entity.Id,
        FinisherId = entity.FinisherId,
        Name = entity.Name,
        Icon = entity.Icon,
        MinRank = entity.MinRank,
        MaxRank = entity.MaxRank,
        Levels = levelEntities.OrderBy(level => level.OrderIndex).Select(level => new PvpRankLevel()
        {
            MinRank = level.MinRank,
            MaxRank = level.MaxRank,
            Points = level.Points
        }).ToArray()
    };
}
