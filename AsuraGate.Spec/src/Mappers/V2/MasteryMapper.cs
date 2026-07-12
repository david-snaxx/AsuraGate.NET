using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class MasteryMapper
{
    public static MasteryEntity ToMasteryEntity(Mastery mastery) => new MasteryEntity()
    {
        Id = mastery.Id,
        Name = mastery.Name,
        Requirement = mastery.Requirement,
        Order = mastery.Order,
        Background = mastery.Background,
        Region = mastery.Region
    };

    public static IEnumerable<MasteryLevelEntity> ToLevelEntities(Mastery mastery) =>
        mastery.Levels.Select((level, index) => new MasteryLevelEntity()
        {
            MasteryId = mastery.Id,
            OrderIndex = index,
            Name = level.Name,
            Description = level.Description,
            Instruction = level.Instruction,
            Icon = level.Icon,
            PointCost = level.PointCost,
            ExpCost = level.ExpCost
        });

    public static Mastery ToModel(MasteryEntity entity, IEnumerable<MasteryLevelEntity> levelEntities) => new Mastery()
    {
        Id = entity.Id,
        Name = entity.Name,
        Requirement = entity.Requirement,
        Order = entity.Order,
        Background = entity.Background,
        Region = entity.Region,
        Levels = levelEntities.OrderBy(level => level.OrderIndex).Select(level => new MasteryLevel()
        {
            Name = level.Name,
            Description = level.Description,
            Instruction = level.Instruction,
            Icon = level.Icon,
            PointCost = level.PointCost,
            ExpCost = level.ExpCost
        }).ToArray()
    };
}
