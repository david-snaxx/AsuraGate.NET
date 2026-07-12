using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountBuildStorageTemplateMapper
{
    public static AccountBuildStorageTemplateEntity ToEntity(string accountId, int orderIndex, AccountBuildStorageTemplate template) => new AccountBuildStorageTemplateEntity()
    {
        AccountId = accountId,
        OrderIndex = orderIndex,
        Name = template.Name,
        Profession = template.Profession,
        SkillsHeal = template.Skills.Heal,
        SkillsElite = template.Skills.Elite,
        HasSkillsUtilities = template.Skills.Utilities is not null,
        AquaticSkillsHeal = template.AquaticSkills.Heal,
        AquaticSkillsElite = template.AquaticSkills.Elite,
        HasAquaticSkillsUtilities = template.AquaticSkills.Utilities is not null,
        HasLegends = template.Legends is not null,
        HasAquaticLegends = template.AquaticLegends is not null
    };

    public static IEnumerable<AccountBuildStorageTemplateSpecializationEntity> ToSpecializationEntities(string accountId, int templateOrderIndex, AccountBuildStorageTemplate template) =>
        template.Specializations.Select((specialization, index) => new AccountBuildStorageTemplateSpecializationEntity()
        {
            AccountId = accountId,
            TemplateOrderIndex = templateOrderIndex,
            OrderIndex = index,
            SpecializationId = specialization.Id,
            HasTraits = specialization.Traits is not null
        });

    public static IEnumerable<AccountBuildStorageTemplateTraitEntity> ToTraitEntities(string accountId, int templateOrderIndex, AccountBuildStorageTemplate template) =>
        template.Specializations.SelectMany((specialization, specIndex) => (specialization.Traits ?? []).Select((traitId, index) => new AccountBuildStorageTemplateTraitEntity()
        {
            AccountId = accountId,
            TemplateOrderIndex = templateOrderIndex,
            SpecializationOrderIndex = specIndex,
            OrderIndex = index,
            TraitId = traitId
        }));

    public static IEnumerable<AccountBuildStorageTemplateUtilityEntity> ToUtilityEntities(string accountId, int templateOrderIndex, AccountBuildStorageTemplate template)
    {
        var land = (template.Skills.Utilities ?? []).Select((skillId, index) => new AccountBuildStorageTemplateUtilityEntity()
        {
            AccountId = accountId,
            TemplateOrderIndex = templateOrderIndex,
            IsAquatic = false,
            OrderIndex = index,
            SkillId = skillId
        });

        var aquatic = (template.AquaticSkills.Utilities ?? []).Select((skillId, index) => new AccountBuildStorageTemplateUtilityEntity()
        {
            AccountId = accountId,
            TemplateOrderIndex = templateOrderIndex,
            IsAquatic = true,
            OrderIndex = index,
            SkillId = skillId
        });

        return land.Concat(aquatic);
    }

    public static IEnumerable<AccountBuildStorageTemplateLegendEntity> ToLegendEntities(string accountId, int templateOrderIndex, AccountBuildStorageTemplate template)
    {
        var land = (template.Legends ?? []).Select((legendId, index) => new AccountBuildStorageTemplateLegendEntity()
        {
            AccountId = accountId,
            TemplateOrderIndex = templateOrderIndex,
            IsAquatic = false,
            OrderIndex = index,
            LegendId = legendId
        });

        var aquatic = (template.AquaticLegends ?? []).Select((legendId, index) => new AccountBuildStorageTemplateLegendEntity()
        {
            AccountId = accountId,
            TemplateOrderIndex = templateOrderIndex,
            IsAquatic = true,
            OrderIndex = index,
            LegendId = legendId
        });

        return land.Concat(aquatic);
    }

    public static AccountBuildStorageTemplate ToModel(
        AccountBuildStorageTemplateEntity entity,
        IEnumerable<AccountBuildStorageTemplateSpecializationEntity> specializationEntities,
        IEnumerable<AccountBuildStorageTemplateTraitEntity> traitEntities,
        IEnumerable<AccountBuildStorageTemplateUtilityEntity> utilityEntities,
        IEnumerable<AccountBuildStorageTemplateLegendEntity> legendEntities)
    {
        var traits = traitEntities.ToList();
        var utilities = utilityEntities.ToList();
        var legends = legendEntities.ToList();

        int[] UtilitiesFor(bool aquatic) => utilities.Where(u => u.IsAquatic == aquatic).OrderBy(u => u.OrderIndex).Select(u => u.SkillId).ToArray();
        string[] LegendsFor(bool aquatic) => legends.Where(l => l.IsAquatic == aquatic).OrderBy(l => l.OrderIndex).Select(l => l.LegendId).ToArray();

        return new AccountBuildStorageTemplate()
        {
            Name = entity.Name,
            Profession = entity.Profession,
            Specializations = specializationEntities.OrderBy(specialization => specialization.OrderIndex).Select(specialization => new BuildStorageSpecialization()
            {
                Id = specialization.SpecializationId,
                Traits = specialization.HasTraits
                    ? traits.Where(trait => trait.SpecializationOrderIndex == specialization.OrderIndex).OrderBy(trait => trait.OrderIndex).Select(trait => trait.TraitId).ToArray()
                    : null
            }).ToArray(),
            Skills = new BuildStorageSkills()
            {
                Heal = entity.SkillsHeal,
                Utilities = entity.HasSkillsUtilities ? UtilitiesFor(false) : null,
                Elite = entity.SkillsElite
            },
            AquaticSkills = new BuildStorageSkills()
            {
                Heal = entity.AquaticSkillsHeal,
                Utilities = entity.HasAquaticSkillsUtilities ? UtilitiesFor(true) : null,
                Elite = entity.AquaticSkillsElite
            },
            Legends = entity.HasLegends ? LegendsFor(false) : null,
            AquaticLegends = entity.HasAquaticLegends ? LegendsFor(true) : null
        };
    }
}
