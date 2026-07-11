using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="PvpRank"/> to <see cref="PvpRankEntity"/>.
/// </summary>
public static class PvpRankMapper
{
    public static PvpRankEntity ToEntity(PvpRank rank) => new PvpRankEntity()
    {
        Id = rank.Id,
        FinisherId = rank.FinisherId,
        Name = rank.Name,
        Icon = rank.Icon,
        MinRank = rank.MinRank,
        MaxRank = rank.MaxRank,
    };

    public static IReadOnlyList<PvpRankLevelEntity> ToLevelEntities(PvpRank rank) =>
        rank.Levels.Select((level, index) => new PvpRankLevelEntity()
        {
            PvpRankId = rank.Id,
            OrderIndex = index,
            MinRank = level.MinRank,
            MaxRank = level.MaxRank,
            Points = level.Points,
        }).ToList();

    public static PvpRankLevel ToLevelModel(PvpRankLevelEntity entity) => new PvpRankLevel() { MinRank = entity.MinRank, MaxRank = entity.MaxRank, Points = entity.Points };

    public static PvpRank ToModel(PvpRankEntity entity, IEnumerable<PvpRankLevelEntity> levels) => new PvpRank()
    {
        Id = entity.Id,
        FinisherId = entity.FinisherId,
        Name = entity.Name,
        Icon = entity.Icon,
        MinRank = entity.MinRank,
        MaxRank = entity.MaxRank,
        Levels = levels.OrderBy(l => l.OrderIndex).Select(ToLevelModel).ToArray(),
    };
}
