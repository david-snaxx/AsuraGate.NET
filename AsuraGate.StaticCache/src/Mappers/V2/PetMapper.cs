using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class PetMapper
{
    public static PetEntity ToPetEntity(Pet pet) => new PetEntity()
    {
        Id = pet.Id,
        Name = pet.Name,
        Description = pet.Description,
        Icon = pet.Icon
    };

    public static IEnumerable<PetSkillEntity> ToSkillEntities(Pet pet) =>
        pet.Skills.Select(skill => new PetSkillEntity()
        {
            PetId = pet.Id,
            SkillId = skill.Id
        });

    public static Pet ToModel(PetEntity entity, IEnumerable<PetSkillEntity> skillEntities) => new Pet()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Skills = skillEntities.Select(skill => new PetSkill() { Id = skill.SkillId }).ToArray()
    };
}
