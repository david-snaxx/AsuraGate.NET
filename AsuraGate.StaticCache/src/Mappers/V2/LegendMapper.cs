using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class LegendMapper
{
    public static LegendEntity ToLegendEntity(Legend legend) => new LegendEntity()
    {
        Id = legend.Id,
        Code = legend.Code,
        Swap = legend.Swap,
        Heal = legend.Heal,
        Elite = legend.Elite
    };

    public static IEnumerable<LegendUtilityEntity> ToUtilityEntities(Legend legend) =>
        legend.Utilities.Select((skillId, index) => new LegendUtilityEntity()
        {
            LegendId = legend.Id,
            OrderIndex = index,
            SkillId = skillId
        });

    public static Legend ToModel(LegendEntity entity, IEnumerable<LegendUtilityEntity> utilityEntities) => new Legend()
    {
        Id = entity.Id,
        Code = entity.Code,
        Swap = entity.Swap,
        Heal = entity.Heal,
        Elite = entity.Elite,
        Utilities = utilityEntities.OrderBy(utility => utility.OrderIndex).Select(utility => utility.SkillId).ToArray()
    };
}
