using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Legend"/> to <see cref="LegendEntity"/>.
/// </summary>
public static class LegendMapper
{
    public static LegendEntity ToEntity(Legend legend) => new LegendEntity()
    {
        Id = legend.Id,
        Code = legend.Code,
        Swap = legend.Swap,
        Heal = legend.Heal,
        Elite = legend.Elite,
    };

    public static IReadOnlyList<LegendUtilityEntity> ToUtilityEntities(Legend legend) =>
        legend.Utilities.Select((skillId, index) => new LegendUtilityEntity() { LegendId = legend.Id, OrderIndex = index, SkillId = skillId }).ToList();

    public static Legend ToModel(LegendEntity entity, IEnumerable<LegendUtilityEntity> utilities) => new Legend()
    {
        Id = entity.Id,
        Code = entity.Code,
        Swap = entity.Swap,
        Heal = entity.Heal,
        Elite = entity.Elite,
        Utilities = utilities.OrderBy(u => u.OrderIndex).Select(u => u.SkillId).ToArray(),
    };
}
