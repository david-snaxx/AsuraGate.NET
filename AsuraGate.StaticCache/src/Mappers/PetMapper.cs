using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Pet"/> to <see cref="PetEntity"/>.
/// </summary>
public static class PetMapper
{
    public static PetEntity ToEntity(Pet pet) => new PetEntity()
    {
        Id = pet.Id,
        Name = pet.Name,
        Description = pet.Description,
        Icon = pet.Icon,
    };

    public static IReadOnlyList<PetSkillEntity> ToSkillEntities(Pet pet) =>
        pet.Skills.Select(skill => new PetSkillEntity() { PetId = pet.Id, SkillId = skill.Id }).ToList();

    public static Pet ToModel(PetEntity entity, IEnumerable<int> skillIds) => new Pet()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Skills = skillIds.Select(id => new PetSkill() { Id = id }).ToArray(),
    };
}
