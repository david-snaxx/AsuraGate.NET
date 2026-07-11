using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Race"/> to <see cref="RaceEntity"/>.
/// </summary>
public static class RaceMapper
{
    public static RaceEntity ToEntity(Race race) => new RaceEntity()
    {
        Id = race.Id,
    };

    public static IReadOnlyList<RaceSkillEntity> ToSkillEntities(Race race) =>
        race.Skills.Select(skillId => new RaceSkillEntity() { RaceId = race.Id, SkillId = skillId }).ToList();

    public static Race ToModel(RaceEntity entity, IEnumerable<int> skills) => new Race()
    {
        Id = entity.Id,
        Skills = skills.ToArray(),
    };
}
