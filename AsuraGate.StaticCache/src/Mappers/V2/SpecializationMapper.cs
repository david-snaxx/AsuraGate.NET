using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class SpecializationMapper
{
    public static SpecializationEntity ToSpecializationEntity(Specialization specialization) => new SpecializationEntity()
    {
        Id = specialization.Id,
        Name = specialization.Name,
        Profession = specialization.Profession,
        Elite = specialization.Elite,
        Icon = specialization.Icon,
        ProfessionIcon = specialization.ProfessionIcon,
        ProfessionIconBig = specialization.ProfessionIconBig,
        Background = specialization.Background,
        WeaponTrait = specialization.WeaponTrait
    };

    public static IEnumerable<SpecializationTraitEntity> ToTraitEntities(Specialization specialization)
    {
        var minorTraits = specialization.MinorTraits.Select((traitId, index) => new SpecializationTraitEntity()
        {
            SpecializationId = specialization.Id,
            IsMajor = false,
            OrderIndex = index,
            TraitId = traitId
        });

        var majorTraits = specialization.MajorTraits.Select((traitId, index) => new SpecializationTraitEntity()
        {
            SpecializationId = specialization.Id,
            IsMajor = true,
            OrderIndex = index,
            TraitId = traitId
        });

        return minorTraits.Concat(majorTraits);
    }

    public static Specialization ToModel(SpecializationEntity entity, IEnumerable<SpecializationTraitEntity> traitEntities)
    {
        var traits = traitEntities.ToList();

        return new Specialization()
        {
            Id = entity.Id,
            Name = entity.Name,
            Profession = entity.Profession,
            Elite = entity.Elite,
            Icon = entity.Icon,
            ProfessionIcon = entity.ProfessionIcon,
            ProfessionIconBig = entity.ProfessionIconBig,
            Background = entity.Background,
            MinorTraits = traits.Where(trait => !trait.IsMajor).OrderBy(trait => trait.OrderIndex).Select(trait => trait.TraitId).ToArray(),
            MajorTraits = traits.Where(trait => trait.IsMajor).OrderBy(trait => trait.OrderIndex).Select(trait => trait.TraitId).ToArray(),
            WeaponTrait = entity.WeaponTrait
        };
    }
}
