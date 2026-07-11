using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Specialization"/> to <see cref="SpecializationEntity"/>. Minor and major traits share one
/// join table (<see cref="SpecializationTraitEntity"/>), discriminated by <c>Slot</c>, since both are
/// "a trait id in a specific order on this specialization" — just gated by two different UI slot types.
/// </summary>
public static class SpecializationMapper
{
    public static SpecializationEntity ToEntity(Specialization specialization) => new SpecializationEntity()
    {
        Id = specialization.Id,
        Name = specialization.Name,
        Profession = specialization.Profession,
        Elite = specialization.Elite,
        Icon = specialization.Icon,
        ProfessionIcon = specialization.ProfessionIcon,
        ProfessionIconBig = specialization.ProfessionIconBig,
        Background = specialization.Background,
        WeaponTrait = specialization.WeaponTrait,
    };

    public static IReadOnlyList<SpecializationTraitEntity> ToTraitEntities(Specialization specialization) =>
        specialization.MinorTraits.Select((traitId, index) => new SpecializationTraitEntity()
        {
            SpecializationId = specialization.Id,
            Slot = "Minor",
            OrderIndex = index,
            TraitId = traitId,
        }).Concat(specialization.MajorTraits.Select((traitId, index) => new SpecializationTraitEntity()
        {
            SpecializationId = specialization.Id,
            Slot = "Major",
            OrderIndex = index,
            TraitId = traitId,
        })).ToList();

    public static Specialization ToModel(SpecializationEntity entity, IEnumerable<SpecializationTraitEntity> traits)
    {
        var traitList = traits.ToList();
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
            MinorTraits = traitList.Where(t => t.Slot == "Minor").OrderBy(t => t.OrderIndex).Select(t => t.TraitId).ToArray(),
            MajorTraits = traitList.Where(t => t.Slot == "Major").OrderBy(t => t.OrderIndex).Select(t => t.TraitId).ToArray(),
            WeaponTrait = entity.WeaponTrait,
        };
    }
}
