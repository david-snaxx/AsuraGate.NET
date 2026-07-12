using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class ProfessionMapper
{
    public static ProfessionEntity ToProfessionEntity(Profession profession) => new ProfessionEntity()
    {
        Id = profession.Id,
        Name = profession.Name,
        Code = profession.Code,
        Icon = profession.Icon,
        IconBig = profession.IconBig
    };

    public static IEnumerable<ProfessionSpecializationEntity> ToSpecializationEntities(Profession profession) =>
        profession.Specializations.Select(specializationId => new ProfessionSpecializationEntity()
        {
            ProfessionId = profession.Id,
            SpecializationId = specializationId
        });

    public static IEnumerable<ProfessionFlagEntity> ToFlagEntities(Profession profession) =>
        profession.Flags.Select(flag => new ProfessionFlagEntity()
        {
            ProfessionId = profession.Id,
            Flag = flag
        });

    public static IEnumerable<ProfessionSkillEntity> ToSkillEntities(Profession profession) =>
        profession.Skills.Select(skill => new ProfessionSkillEntity()
        {
            ProfessionId = profession.Id,
            SkillId = skill.Id,
            Slot = skill.Slot,
            Type = skill.Type,
            Source = skill.Source
        });

    public static IEnumerable<ProfessionSkillPaletteEntity> ToSkillPaletteEntities(Profession profession) =>
        profession.SkillsByPalette.Select(pair => new ProfessionSkillPaletteEntity()
        {
            ProfessionId = profession.Id,
            PaletteId = pair[0],
            SkillId = pair[1]
        });

    public static IEnumerable<ProfessionTrainingEntity> ToTrainingEntities(Profession profession) =>
        profession.Training.Select((training, index) => new ProfessionTrainingEntity()
        {
            ProfessionId = profession.Id,
            OrderIndex = index,
            TrainingId = training.Id,
            Category = training.Category,
            Name = training.Name
        });

    public static IEnumerable<ProfessionTrainingTrackEntryEntity> ToTrainingTrackEntryEntities(Profession profession) =>
        profession.Training.SelectMany(training => training.Track.Select((entry, index) => new ProfessionTrainingTrackEntryEntity()
        {
            ProfessionId = profession.Id,
            TrainingId = training.Id,
            OrderIndex = index,
            Cost = entry.Cost,
            Type = entry.Type,
            SkillId = entry.SkillId,
            TraitId = entry.TraitId
        }));

    public static IEnumerable<ProfessionWeaponEntity> ToWeaponEntities(Profession profession) =>
        profession.Weapons.Select(pair => new ProfessionWeaponEntity()
        {
            ProfessionId = profession.Id,
            WeaponType = pair.Key,
            SpecializationId = pair.Value.Specialization
        });

    public static IEnumerable<ProfessionWeaponFlagEntity> ToWeaponFlagEntities(Profession profession) =>
        profession.Weapons.SelectMany(pair => pair.Value.Flags.Select(flag => new ProfessionWeaponFlagEntity()
        {
            ProfessionId = profession.Id,
            WeaponType = pair.Key,
            Flag = flag
        }));

    public static IEnumerable<ProfessionWeaponSkillEntity> ToWeaponSkillEntities(Profession profession) =>
        profession.Weapons.SelectMany(pair => pair.Value.Skills.Select(skill => new ProfessionWeaponSkillEntity()
        {
            ProfessionId = profession.Id,
            WeaponType = pair.Key,
            SkillId = skill.Id,
            Slot = skill.Slot,
            Offhand = skill.Offhand,
            Attunement = skill.Attunement,
            Source = skill.Source
        }));

    public static Profession ToModel(
        ProfessionEntity entity,
        IEnumerable<ProfessionSpecializationEntity> specializationEntities,
        IEnumerable<ProfessionFlagEntity> flagEntities,
        IEnumerable<ProfessionSkillEntity> skillEntities,
        IEnumerable<ProfessionSkillPaletteEntity> skillPaletteEntities,
        IEnumerable<ProfessionTrainingEntity> trainingEntities,
        IEnumerable<ProfessionTrainingTrackEntryEntity> trainingTrackEntryEntities,
        IEnumerable<ProfessionWeaponEntity> weaponEntities,
        IEnumerable<ProfessionWeaponFlagEntity> weaponFlagEntities,
        IEnumerable<ProfessionWeaponSkillEntity> weaponSkillEntities)
    {
        var trackEntries = trainingTrackEntryEntities.ToList();
        var weaponFlags = weaponFlagEntities.ToList();
        var weaponSkills = weaponSkillEntities.ToList();

        return new Profession()
        {
            Id = entity.Id,
            Name = entity.Name,
            Code = entity.Code,
            Icon = entity.Icon,
            IconBig = entity.IconBig,
            Specializations = specializationEntities.Select(specialization => specialization.SpecializationId).ToArray(),
            Training = trainingEntities.OrderBy(training => training.OrderIndex).Select(training => new ProfessionTraining()
            {
                Id = training.TrainingId,
                Category = training.Category,
                Name = training.Name,
                Track = trackEntries
                    .Where(entry => entry.TrainingId == training.TrainingId)
                    .OrderBy(entry => entry.OrderIndex)
                    .Select(entry => new TrackEntry()
                    {
                        Cost = entry.Cost,
                        Type = entry.Type,
                        SkillId = entry.SkillId,
                        TraitId = entry.TraitId
                    }).ToArray()
            }).ToArray(),
            Weapons = weaponEntities.ToDictionary(weapon => weapon.WeaponType, weapon => new WeaponDetails()
            {
                Specialization = weapon.SpecializationId,
                Flags = weaponFlags.Where(flag => flag.WeaponType == weapon.WeaponType).Select(flag => flag.Flag).ToArray(),
                Skills = weaponSkills.Where(skill => skill.WeaponType == weapon.WeaponType).Select(skill => new WeaponSkill()
                {
                    Id = skill.SkillId,
                    Slot = skill.Slot,
                    Offhand = skill.Offhand,
                    Attunement = skill.Attunement,
                    Source = skill.Source
                }).ToArray()
            }),
            Flags = flagEntities.Select(flag => flag.Flag).ToArray(),
            Skills = skillEntities.Select(skill => new ProfessionSkill()
            {
                Id = skill.SkillId,
                Slot = skill.Slot,
                Type = skill.Type,
                Source = skill.Source
            }).ToArray(),
            SkillsByPalette = skillPaletteEntities.Select(pair => new[] { pair.PaletteId, pair.SkillId }).ToArray()
        };
    }
}
