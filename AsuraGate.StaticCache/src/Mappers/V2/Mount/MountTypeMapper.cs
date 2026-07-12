using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.StaticCache.Entities.V2.Mount;

namespace AsuraGate.StaticCache.Mappers.V2.Mount;

public static class MountTypeMapper
{
    public static MountTypeEntity ToMountTypeEntity(MountType mountType) => new MountTypeEntity()
    {
        Id = mountType.Id,
        Name = mountType.Name,
        DefaultSkin = mountType.DefaultSkin,
        Guid = mountType.Guid
    };

    public static IEnumerable<MountTypeSkinEntity> ToSkinEntities(MountType mountType) =>
        mountType.Skins.Select(skinId => new MountTypeSkinEntity() { MountTypeId = mountType.Id, SkinId = skinId });

    public static IEnumerable<MountTypeSkillEntity> ToSkillEntities(MountType mountType) =>
        mountType.Skills.Select(skill => new MountTypeSkillEntity() { MountTypeId = mountType.Id, SkillId = skill.Id, Slot = skill.Slot });

    public static MountType ToModel(
        MountTypeEntity entity,
        IEnumerable<MountTypeSkinEntity> skinEntities,
        IEnumerable<MountTypeSkillEntity> skillEntities) => new MountType()
    {
        Id = entity.Id,
        Name = entity.Name,
        DefaultSkin = entity.DefaultSkin,
        Skins = skinEntities.Select(skin => skin.SkinId).ToArray(),
        Skills = skillEntities.Select(skill => new MountSkill() { Id = skill.SkillId, Slot = skill.Slot }).ToArray(),
        Guid = entity.Guid
    };
}
