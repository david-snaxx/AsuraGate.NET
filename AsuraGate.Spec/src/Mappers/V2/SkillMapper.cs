using System.Text.Json;
using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class SkillMapper
{
    public static SkillEntity ToSkillEntity(Skill skill) => new SkillEntity()
    {
        Id = skill.Id,
        Name = skill.Name,
        Description = skill.Description,
        Icon = skill.Icon,
        ChatLink = skill.ChatLink,
        Type = skill.Type,
        WeaponType = skill.WeaponType,
        Slot = skill.Slot,
        Attunement = skill.Attunement,
        Cost = skill.Cost,
        DualWield = skill.DualWield,
        FlipSkill = skill.FlipSkill,
        Initiative = skill.Initiative,
        NextChain = skill.NextChain,
        PreviousChain = skill.PreviousChain,
        Specialization = skill.Specialization
    };

    public static IEnumerable<SkillProfessionEntity> ToProfessionEntities(Skill skill) =>
        skill.Professions.Select(profession => new SkillProfessionEntity() { SkillId = skill.Id, Profession = profession });

    public static IEnumerable<SkillCategoryEntity> ToCategoryEntities(Skill skill) =>
        skill.Categories.Select(category => new SkillCategoryEntity() { SkillId = skill.Id, Category = category });

    public static IEnumerable<SkillFlagEntity> ToFlagEntities(Skill skill) =>
        skill.Flags.Select(flag => new SkillFlagEntity() { SkillId = skill.Id, Flag = flag });

    public static IEnumerable<SkillRelatedSkillEntity> ToRelatedSkillEntities(Skill skill)
    {
        var transform = skill.TransformSkills.Select((id, index) => new SkillRelatedSkillEntity() { SkillId = skill.Id, OrderIndex = index, Relation = "Transform", RelatedSkillId = id });
        var bundle = skill.BundleSkills.Select((id, index) => new SkillRelatedSkillEntity() { SkillId = skill.Id, OrderIndex = index, Relation = "Bundle", RelatedSkillId = id });
        var toolbelt = skill.ToolbeltSkills.Select((id, index) => new SkillRelatedSkillEntity() { SkillId = skill.Id, OrderIndex = index, Relation = "Toolbelt", RelatedSkillId = id });
        return transform.Concat(bundle).Concat(toolbelt);
    }

    private static SkillFactEntity ToFactEntity(int skillId, bool isTraited, int orderIndex, SkillFact? fact)
    {
        var entity = new SkillFactEntity()
        {
            SkillId = skillId,
            IsTraited = isTraited,
            OrderIndex = orderIndex,
            Text = fact?.Text,
            Icon = fact?.Icon,
            FactType = fact?.Type ?? string.Empty
        };

        switch (fact)
        {
            case SkillFactAttributeAdjust f:
                entity.ValueInt = f.Value;
                entity.Target = f.Target;
                break;
            case SkillFactBuff f:
                entity.Status = f.Status;
                entity.BuffDescription = f.Description;
                entity.ApplyCount = f.ApplyCount;
                entity.Duration = f.Duration;
                break;
            case SkillFactComboField f:
                entity.FieldType = f.FieldType;
                break;
            case SkillFactComboFinisher f:
                entity.FinisherType = f.FinisherType;
                entity.Percent = f.Percent;
                break;
            case SkillFactDamage f:
                entity.HitCount = f.HitCount;
                entity.DamageMultiplier = f.DamageMultiplier;
                break;
            case SkillFactDistance f:
                entity.Distance = f.Distance;
                break;
            case SkillFactDuration f:
                entity.Duration = f.Duration;
                break;
            case SkillFactHeal f:
                entity.HitCount = f.HitCount;
                break;
            case SkillFactHealingAdjust f:
                entity.HitCount = f.HitCount;
                break;
            case SkillFactNumber f:
                entity.ValueInt = f.Value;
                break;
            case SkillFactPercent f:
                entity.Percent = f.Percent;
                break;
            case SkillFactPrefixedBuff f:
                entity.Duration = f.Duration;
                entity.Status = f.Status;
                entity.BuffDescription = f.Description;
                entity.ApplyCount = f.ApplyCount;
                entity.PrefixText = f.Prefix?.Text;
                entity.PrefixIcon = f.Prefix?.Icon;
                entity.PrefixStatus = f.Prefix?.Status;
                entity.PrefixDescription = f.Prefix?.Description;
                break;
            case SkillFactRadius f:
                entity.Distance = f.Distance;
                break;
            case SkillFactRange f:
                entity.ValueInt = f.Value;
                break;
            case SkillFactRecharge f:
                entity.ValueInt = f.Value;
                break;
            case SkillFactStunBreak f:
                entity.BoolValue = f.Value;
                break;
            case SkillFactTime f:
                entity.Duration = f.Duration;
                break;
            case SkillFactUnblockable f:
                entity.BoolValue = f.Value;
                break;
        }

        return entity;
    }

    private static SkillFact? FromFactEntity(SkillFactEntity entity)
    {
        SkillFact? fact = entity.FactType switch
        {
            "AttributeAdjust" => new SkillFactAttributeAdjust() { Value = entity.ValueInt ?? 0, Target = entity.Target },
            "Buff" => new SkillFactBuff() { Status = entity.Status, Description = entity.BuffDescription, ApplyCount = entity.ApplyCount, Duration = entity.Duration },
            "ComboField" => new SkillFactComboField() { FieldType = entity.FieldType ?? string.Empty },
            "ComboFinisher" => new SkillFactComboFinisher() { FinisherType = entity.FinisherType ?? string.Empty, Percent = entity.Percent ?? 0 },
            "Damage" => new SkillFactDamage() { HitCount = entity.HitCount ?? 0, DamageMultiplier = entity.DamageMultiplier ?? 0 },
            "Distance" => new SkillFactDistance() { Distance = entity.Distance ?? 0 },
            "Duration" => new SkillFactDuration() { Duration = entity.Duration ?? 0 },
            "Heal" => new SkillFactHeal() { HitCount = entity.HitCount ?? 0 },
            "HealingAdjust" => new SkillFactHealingAdjust() { HitCount = entity.HitCount ?? 0 },
            "NoData" => new SkillFactNoData(),
            "Number" => new SkillFactNumber() { Value = entity.ValueInt ?? 0 },
            "Percent" => new SkillFactPercent() { Percent = entity.Percent ?? 0 },
            "PrefixedBuff" => new SkillFactPrefixedBuff()
            {
                Duration = entity.Duration ?? 0,
                Status = entity.Status,
                Description = entity.BuffDescription,
                ApplyCount = entity.ApplyCount ?? 0,
                Prefix = entity.PrefixText is null && entity.PrefixIcon is null && entity.PrefixStatus is null && entity.PrefixDescription is null
                    ? null
                    : new SkillFactPrefix() { Text = entity.PrefixText, Icon = entity.PrefixIcon, Status = entity.PrefixStatus, Description = entity.PrefixDescription }
            },
            "Radius" => new SkillFactRadius() { Distance = entity.Distance ?? 0 },
            "Range" => new SkillFactRange() { Value = entity.ValueInt ?? 0 },
            "Recharge" => new SkillFactRecharge() { Value = entity.ValueInt ?? 0 },
            "StunBreak" => new SkillFactStunBreak() { Value = entity.BoolValue ?? false },
            "Time" => new SkillFactTime() { Duration = entity.Duration ?? 0 },
            "Unblockable" => new SkillFactUnblockable() { Value = entity.BoolValue ?? false },
            _ => new SkillFact()
        };

        return fact with { Text = entity.Text, Icon = entity.Icon, Type = entity.FactType };
    }

    public static IEnumerable<SkillFactEntity> ToFactEntities(Skill skill) =>
        skill.GetFacts().Select((fact, index) => ToFactEntity(skill.Id, false, index, fact));

    public static IEnumerable<SkillFactEntity> ToTraitedFactEntities(Skill skill) =>
        skill.GetTraitedFacts().Select((fact, index) => ToFactEntity(skill.Id, true, index, fact));

    public static Skill ToModel(
        SkillEntity entity,
        IEnumerable<SkillProfessionEntity> professionEntities,
        IEnumerable<SkillCategoryEntity> categoryEntities,
        IEnumerable<SkillFlagEntity> flagEntities,
        IEnumerable<SkillRelatedSkillEntity> relatedSkillEntities,
        IEnumerable<SkillFactEntity> factEntities)
    {
        var related = relatedSkillEntities.ToList();
        var facts = factEntities.ToList();

        JsonElement[] BuildFacts(bool traited) => facts
            .Where(fact => fact.IsTraited == traited)
            .OrderBy(fact => fact.OrderIndex)
            .Select(fact => JsonSerializer.SerializeToElement(FromFactEntity(fact)))
            .ToArray();

        return new Skill()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Icon = entity.Icon,
            ChatLink = entity.ChatLink,
            Type = entity.Type,
            WeaponType = entity.WeaponType,
            Professions = professionEntities.Select(profession => profession.Profession).ToArray(),
            Slot = entity.Slot,
            Facts = BuildFacts(false),
            TraitedFacts = BuildFacts(true),
            Categories = categoryEntities.Select(category => category.Category).ToArray(),
            Attunement = entity.Attunement,
            Cost = entity.Cost,
            DualWield = entity.DualWield,
            FlipSkill = entity.FlipSkill,
            Initiative = entity.Initiative,
            NextChain = entity.NextChain,
            PreviousChain = entity.PreviousChain,
            TransformSkills = related.Where(r => r.Relation == "Transform").OrderBy(r => r.OrderIndex).Select(r => r.RelatedSkillId).ToArray(),
            BundleSkills = related.Where(r => r.Relation == "Bundle").OrderBy(r => r.OrderIndex).Select(r => r.RelatedSkillId).ToArray(),
            ToolbeltSkills = related.Where(r => r.Relation == "Toolbelt").OrderBy(r => r.OrderIndex).Select(r => r.RelatedSkillId).ToArray(),
            Flags = flagEntities.Select(flag => flag.Flag).ToArray(),
            Specialization = entity.Specialization
        };
    }
}
