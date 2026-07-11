using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Profession"/> to <see cref="ProfessionEntity"/>. <see cref="ProfessionTrainingEntity"/> and
/// <see cref="ProfessionWeaponEntity"/> use DB-assigned ids (not provided by the API), so their child collection
/// mappers take the already-persisted parent id as a parameter.
/// </summary>
public static class ProfessionMapper
{
    public static ProfessionEntity ToEntity(Profession profession) => new ProfessionEntity()
    {
        Id = profession.Id,
        Name = profession.Name,
        Code = profession.Code,
        Icon = profession.Icon,
        IconBig = profession.IconBig,
    };

    public static IReadOnlyList<ProfessionSpecializationEntity> ToSpecializationEntities(Profession profession) =>
        profession.Specializations.Select((specId, index) => new ProfessionSpecializationEntity()
        {
            ProfessionId = profession.Id,
            OrderIndex = index,
            SpecializationId = specId,
        }).ToList();

    public static IReadOnlyList<ProfessionFlagEntity> ToFlagEntities(Profession profession) =>
        profession.Flags.Select(flag => new ProfessionFlagEntity() { ProfessionId = profession.Id, Flag = flag }).ToList();

    public static ProfessionTrainingEntity ToTrainingEntity(ProfessionTraining training, string professionId) => new ProfessionTrainingEntity()
    {
        ProfessionId = professionId,
        TrainingId = training.Id,
        Category = training.Category,
        Name = training.Name,
    };

    public static IReadOnlyList<ProfessionTrainingTrackEntryEntity> ToTrackEntryEntities(ProfessionTraining training, int professionTrainingId) =>
        training.Track.Select((entry, index) => new ProfessionTrainingTrackEntryEntity()
        {
            ProfessionTrainingId = professionTrainingId,
            OrderIndex = index,
            Cost = entry.Cost,
            Type = entry.Type,
            SkillId = entry.SkillId,
            TraitId = entry.TraitId,
        }).ToList();

    public static TrackEntry ToTrackEntryModel(ProfessionTrainingTrackEntryEntity entity) => new TrackEntry()
    {
        Cost = entity.Cost,
        Type = entity.Type,
        SkillId = entity.SkillId,
        TraitId = entity.TraitId,
    };

    public static ProfessionTraining ToTrainingModel(ProfessionTrainingEntity entity, IEnumerable<TrackEntry> track) => new ProfessionTraining()
    {
        Id = entity.TrainingId,
        Category = entity.Category,
        Name = entity.Name,
        Track = track.ToArray(),
    };

    public static ProfessionWeaponEntity ToWeaponEntity(string weaponType, WeaponDetails weapon, string professionId) => new ProfessionWeaponEntity()
    {
        ProfessionId = professionId,
        WeaponType = weaponType,
        SpecializationId = weapon.Specialization,
    };

    public static IReadOnlyList<ProfessionWeaponFlagEntity> ToWeaponFlagEntities(WeaponDetails weapon, int professionWeaponId) =>
        weapon.Flags.Select(flag => new ProfessionWeaponFlagEntity() { ProfessionWeaponId = professionWeaponId, Flag = flag }).ToList();

    public static IReadOnlyList<ProfessionWeaponSkillEntity> ToWeaponSkillEntities(WeaponDetails weapon, int professionWeaponId) =>
        weapon.Skills.Select((skill, index) => new ProfessionWeaponSkillEntity()
        {
            ProfessionWeaponId = professionWeaponId,
            OrderIndex = index,
            SkillId = skill.Id,
            Slot = skill.Slot,
            Offhand = skill.Offhand,
            Attunement = skill.Attunement,
            Source = skill.Source,
        }).ToList();

    public static WeaponSkill ToWeaponSkillModel(ProfessionWeaponSkillEntity entity) => new WeaponSkill()
    {
        Id = entity.SkillId,
        Slot = entity.Slot,
        Offhand = entity.Offhand,
        Attunement = entity.Attunement,
        Source = entity.Source,
    };

    public static WeaponDetails ToWeaponModel(ProfessionWeaponEntity entity, IEnumerable<string> flags, IEnumerable<WeaponSkill> skills) => new WeaponDetails()
    {
        Specialization = entity.SpecializationId,
        Flags = flags.ToArray(),
        Skills = skills.ToArray(),
    };

    public static IReadOnlyList<ProfessionSkillEntity> ToSkillEntities(Profession profession) =>
        profession.Skills.Select((skill, index) => new ProfessionSkillEntity()
        {
            ProfessionId = profession.Id,
            OrderIndex = index,
            SkillId = skill.Id,
            Slot = skill.Slot,
            Type = skill.Type,
            Source = skill.Source,
        }).ToList();

    public static ProfessionSkill ToSkillModel(ProfessionSkillEntity entity) => new ProfessionSkill()
    {
        Id = entity.SkillId,
        Slot = entity.Slot,
        Type = entity.Type,
        Source = entity.Source,
    };

    public static IReadOnlyList<ProfessionSkillPaletteEntity> ToSkillPaletteEntities(Profession profession) =>
        profession.SkillsByPalette.Select(pair => new ProfessionSkillPaletteEntity()
        {
            ProfessionId = profession.Id,
            PaletteId = pair.ElementAtOrDefault(0),
            SkillId = pair.ElementAtOrDefault(1),
        }).ToList();

    public static Profession ToModel(
        ProfessionEntity entity,
        IEnumerable<int> specializations,
        IEnumerable<string> flags,
        IEnumerable<ProfessionTraining> training,
        IReadOnlyDictionary<string, WeaponDetails> weapons,
        IEnumerable<ProfessionSkill> skills,
        IEnumerable<ProfessionSkillPaletteEntity> skillsByPalette) => new Profession()
    {
        Id = entity.Id,
        Name = entity.Name,
        Code = entity.Code,
        Icon = entity.Icon,
        IconBig = entity.IconBig,
        Specializations = specializations.ToArray(),
        Training = training.ToArray(),
        Weapons = weapons.ToDictionary(w => w.Key, w => w.Value),
        Flags = flags.ToArray(),
        Skills = skills.ToArray(),
        SkillsByPalette = skillsByPalette.Select(p => new[] { p.PaletteId, p.SkillId }).ToArray(),
    };
}
