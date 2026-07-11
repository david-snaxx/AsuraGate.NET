using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="MountType"/> to <see cref="MountTypeEntity"/>.
/// </summary>
public static class MountTypeMapper
{
    public static MountTypeEntity ToEntity(MountType mount) => new MountTypeEntity()
    {
        Id = mount.Id,
        Name = mount.Name,
        DefaultSkin = mount.DefaultSkin,
        Guid = mount.Guid,
    };

    public static IReadOnlyList<MountTypeSkinEntity> ToSkinEntities(MountType mount) =>
        mount.Skins.Select(skinId => new MountTypeSkinEntity() { MountTypeId = mount.Id, SkinId = skinId }).ToList();

    public static IReadOnlyList<MountTypeSkillEntity> ToSkillEntities(MountType mount) =>
        mount.Skills.Select((skill, index) => new MountTypeSkillEntity()
        {
            MountTypeId = mount.Id,
            OrderIndex = index,
            SkillId = skill.Id,
            Slot = skill.Slot,
        }).ToList();

    public static MountSkill ToSkillModel(MountTypeSkillEntity entity) => new MountSkill() { Id = entity.SkillId, Slot = entity.Slot };

    public static MountType ToModel(MountTypeEntity entity, IEnumerable<int> skins, IEnumerable<MountTypeSkillEntity> skills) => new MountType()
    {
        Id = entity.Id,
        Name = entity.Name,
        DefaultSkin = entity.DefaultSkin,
        Skins = skins.ToArray(),
        Skills = skills.OrderBy(s => s.OrderIndex).Select(ToSkillModel).ToArray(),
        Guid = entity.Guid,
    };
}
