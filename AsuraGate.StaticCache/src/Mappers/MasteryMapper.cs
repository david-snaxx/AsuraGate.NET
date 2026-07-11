using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Mastery"/> to <see cref="MasteryEntity"/>.
/// </summary>
public static class MasteryMapper
{
    public static MasteryEntity ToEntity(Mastery mastery) => new MasteryEntity()
    {
        Id = mastery.Id,
        Name = mastery.Name,
        Requirement = mastery.Requirement,
        Order = mastery.Order,
        Background = mastery.Background,
        Region = mastery.Region,
    };

    public static IReadOnlyList<MasteryLevelEntity> ToLevelEntities(Mastery mastery) =>
        mastery.Levels.Select((level, index) => new MasteryLevelEntity()
        {
            MasteryId = mastery.Id,
            OrderIndex = index,
            Name = level.Name,
            Description = level.Description,
            Instruction = level.Instruction,
            Icon = level.Icon,
            PointCost = level.PointCost,
            ExpCost = level.ExpCost,
        }).ToList();

    public static MasteryLevel ToLevelModel(MasteryLevelEntity entity) => new MasteryLevel()
    {
        Name = entity.Name,
        Description = entity.Description,
        Instruction = entity.Instruction,
        Icon = entity.Icon,
        PointCost = entity.PointCost,
        ExpCost = entity.ExpCost,
    };

    public static Mastery ToModel(MasteryEntity entity, IEnumerable<MasteryLevelEntity> levels) => new Mastery()
    {
        Id = entity.Id,
        Name = entity.Name,
        Requirement = entity.Requirement,
        Order = entity.Order,
        Background = entity.Background,
        Region = entity.Region,
        Levels = levels.OrderBy(l => l.OrderIndex).Select(ToLevelModel).ToArray(),
    };
}
