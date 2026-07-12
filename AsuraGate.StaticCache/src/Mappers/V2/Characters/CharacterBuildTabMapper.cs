using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.StaticCache.Entities.V2.Characters;

namespace AsuraGate.StaticCache.Mappers.V2.Characters;

public static class CharacterBuildTabMapper
{
    public static CharacterBuildTabEntity ToEntity(string characterName, CharacterBuildTab buildTab) => new CharacterBuildTabEntity()
    {
        CharacterName = characterName,
        Tab = buildTab.Tab,
        IsActive = buildTab.IsActive,
        BuildName = buildTab.Build.Name,
        Profession = buildTab.Build.Profession,
        SkillsHeal = buildTab.Build.Skills.Heal,
        SkillsElite = buildTab.Build.Skills.Elite,
        HasSkillsUtilities = buildTab.Build.Skills.Utilities is not null,
        AquaticSkillsHeal = buildTab.Build.AquaticSkills.Heal,
        AquaticSkillsElite = buildTab.Build.AquaticSkills.Elite,
        HasAquaticSkillsUtilities = buildTab.Build.AquaticSkills.Utilities is not null,
        HasLegends = buildTab.Build.Legends is not null,
        HasAquaticLegends = buildTab.Build.AquaticLegends is not null,
        HasPets = buildTab.Build.Pets is not null,
        HasTerrestrialPets = buildTab.Build.Pets?.Terrestrial is not null,
        HasAquaticPets = buildTab.Build.Pets?.Aquatic is not null
    };

    public static IEnumerable<CharacterBuildTabSpecializationEntity> ToSpecializationEntities(string characterName, CharacterBuildTab buildTab) =>
        buildTab.Build.Specializations.Select((specialization, index) => new CharacterBuildTabSpecializationEntity()
        {
            CharacterName = characterName,
            Tab = buildTab.Tab,
            OrderIndex = index,
            SpecializationId = specialization.Id,
            HasTraits = specialization.Traits is not null
        });

    public static IEnumerable<CharacterBuildTabTraitEntity> ToTraitEntities(string characterName, CharacterBuildTab buildTab) =>
        buildTab.Build.Specializations.SelectMany((specialization, specIndex) => (specialization.Traits ?? []).Select((traitId, index) => new CharacterBuildTabTraitEntity()
        {
            CharacterName = characterName,
            Tab = buildTab.Tab,
            SpecializationOrderIndex = specIndex,
            OrderIndex = index,
            TraitId = traitId
        }));

    public static IEnumerable<CharacterBuildTabUtilityEntity> ToUtilityEntities(string characterName, CharacterBuildTab buildTab)
    {
        var land = (buildTab.Build.Skills.Utilities ?? []).Select((skillId, index) => new CharacterBuildTabUtilityEntity()
        {
            CharacterName = characterName,
            Tab = buildTab.Tab,
            IsAquatic = false,
            OrderIndex = index,
            SkillId = skillId
        });

        var aquatic = (buildTab.Build.AquaticSkills.Utilities ?? []).Select((skillId, index) => new CharacterBuildTabUtilityEntity()
        {
            CharacterName = characterName,
            Tab = buildTab.Tab,
            IsAquatic = true,
            OrderIndex = index,
            SkillId = skillId
        });

        return land.Concat(aquatic);
    }

    public static IEnumerable<CharacterBuildTabLegendEntity> ToLegendEntities(string characterName, CharacterBuildTab buildTab)
    {
        var land = (buildTab.Build.Legends ?? []).Select((legendId, index) => new CharacterBuildTabLegendEntity()
        {
            CharacterName = characterName,
            Tab = buildTab.Tab,
            IsAquatic = false,
            OrderIndex = index,
            LegendId = legendId
        });

        var aquatic = (buildTab.Build.AquaticLegends ?? []).Select((legendId, index) => new CharacterBuildTabLegendEntity()
        {
            CharacterName = characterName,
            Tab = buildTab.Tab,
            IsAquatic = true,
            OrderIndex = index,
            LegendId = legendId
        });

        return land.Concat(aquatic);
    }

    public static IEnumerable<CharacterBuildTabPetEntity> ToPetEntities(string characterName, CharacterBuildTab buildTab)
    {
        var terrestrial = (buildTab.Build.Pets?.Terrestrial ?? []).Select((petId, index) => new CharacterBuildTabPetEntity()
        {
            CharacterName = characterName,
            Tab = buildTab.Tab,
            IsAquatic = false,
            OrderIndex = index,
            PetId = petId
        });

        var aquatic = (buildTab.Build.Pets?.Aquatic ?? []).Select((petId, index) => new CharacterBuildTabPetEntity()
        {
            CharacterName = characterName,
            Tab = buildTab.Tab,
            IsAquatic = true,
            OrderIndex = index,
            PetId = petId
        });

        return terrestrial.Concat(aquatic);
    }

    public static CharacterBuildTab ToModel(
        CharacterBuildTabEntity entity,
        IEnumerable<CharacterBuildTabSpecializationEntity> specializationEntities,
        IEnumerable<CharacterBuildTabTraitEntity> traitEntities,
        IEnumerable<CharacterBuildTabUtilityEntity> utilityEntities,
        IEnumerable<CharacterBuildTabLegendEntity> legendEntities,
        IEnumerable<CharacterBuildTabPetEntity> petEntities)
    {
        var traits = traitEntities.ToList();
        var utilities = utilityEntities.ToList();
        var legends = legendEntities.ToList();
        var pets = petEntities.ToList();

        int[] UtilitiesFor(bool aquatic) => utilities.Where(u => u.IsAquatic == aquatic).OrderBy(u => u.OrderIndex).Select(u => u.SkillId).ToArray();
        string[] LegendsFor(bool aquatic) => legends.Where(l => l.IsAquatic == aquatic).OrderBy(l => l.OrderIndex).Select(l => l.LegendId).ToArray();
        int[] PetsFor(bool aquatic) => pets.Where(p => p.IsAquatic == aquatic).OrderBy(p => p.OrderIndex).Select(p => p.PetId).ToArray();

        return new CharacterBuildTab()
        {
            Tab = entity.Tab,
            IsActive = entity.IsActive,
            Build = new CharacterBuild()
            {
                Name = entity.BuildName,
                Profession = entity.Profession,
                Specializations = specializationEntities.OrderBy(specialization => specialization.OrderIndex).Select(specialization => new CharacterBuildSpecialization()
                {
                    Id = specialization.SpecializationId,
                    Traits = specialization.HasTraits
                        ? traits.Where(trait => trait.SpecializationOrderIndex == specialization.OrderIndex).OrderBy(trait => trait.OrderIndex).Select(trait => trait.TraitId).ToArray()
                        : null
                }).ToArray(),
                Skills = new CharacterBuildSkills() { Heal = entity.SkillsHeal, Utilities = entity.HasSkillsUtilities ? UtilitiesFor(false) : null, Elite = entity.SkillsElite },
                AquaticSkills = new CharacterBuildSkills() { Heal = entity.AquaticSkillsHeal, Utilities = entity.HasAquaticSkillsUtilities ? UtilitiesFor(true) : null, Elite = entity.AquaticSkillsElite },
                Legends = entity.HasLegends ? LegendsFor(false) : null,
                AquaticLegends = entity.HasAquaticLegends ? LegendsFor(true) : null,
                Pets = entity.HasPets ? new CharacterBuildPets()
                {
                    Terrestrial = entity.HasTerrestrialPets ? PetsFor(false) : null,
                    Aquatic = entity.HasAquaticPets ? PetsFor(true) : null
                } : null
            }
        };
    }
}
