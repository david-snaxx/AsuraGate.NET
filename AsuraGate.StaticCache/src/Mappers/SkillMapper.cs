using System.Text.Json;
using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Skill"/> to <see cref="SkillEntity"/>. <see cref="Skill.Facts"/>/<see cref="Skill.TraitedFacts"/>
/// are raw <see cref="JsonElement"/>s in the model (deserialized on demand via <see cref="Skill.GetFacts"/>); this
/// mapper resolves them into the concrete <see cref="SkillFact"/> subtype up front so each fact can be flattened
/// into a <see cref="SkillFactEntity"/> row, and re-serializes them back into <see cref="JsonElement"/> on the way out.
/// </summary>
public static class SkillMapper
{
    public static SkillEntity ToEntity(Skill skill) => new SkillEntity()
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
        Specialization = skill.Specialization,
    };

    public static IReadOnlyList<SkillProfessionEntity> ToProfessionEntities(Skill skill) =>
        skill.Professions.Select(profession => new SkillProfessionEntity() { SkillId = skill.Id, Profession = profession }).ToList();

    public static IReadOnlyList<SkillCategoryEntity> ToCategoryEntities(Skill skill) =>
        skill.Categories.Select(category => new SkillCategoryEntity() { SkillId = skill.Id, Category = category }).ToList();

    public static IReadOnlyList<SkillFlagEntity> ToFlagEntities(Skill skill) =>
        skill.Flags.Select(flag => new SkillFlagEntity() { SkillId = skill.Id, Flag = flag }).ToList();

    public static IReadOnlyList<SkillRelatedSkillEntity> ToRelatedSkillEntities(Skill skill) =>
        skill.TransformSkills.Select((id, index) => new SkillRelatedSkillEntity() { SkillId = skill.Id, Relation = "Transform", OrderIndex = index, RelatedSkillId = id })
            .Concat(skill.BundleSkills.Select((id, index) => new SkillRelatedSkillEntity() { SkillId = skill.Id, Relation = "Bundle", OrderIndex = index, RelatedSkillId = id }))
            .Concat(skill.ToolbeltSkills.Select((id, index) => new SkillRelatedSkillEntity() { SkillId = skill.Id, Relation = "Toolbelt", OrderIndex = index, RelatedSkillId = id }))
            .ToList();

    public static IReadOnlyList<SkillFactEntity> ToFactEntities(Skill skill)
    {
        var facts = skill.GetFacts().Select((fact, index) => ToFactEntity(fact, skill.Id, "Base", index));
        var traitedFacts = skill.GetTraitedFacts().Select((fact, index) => ToFactEntity(fact, skill.Id, "Traited", index));
        return facts.Concat(traitedFacts).Where(f => f is not null).Select(f => f!).ToList();
    }

    private static SkillFactEntity? ToFactEntity(SkillFact? fact, int skillId, string kind, int orderIndex)
    {
        if (fact is null) return null;

        var entity = new SkillFactEntity()
        {
            SkillId = skillId,
            Kind = kind,
            OrderIndex = orderIndex,
            Text = fact.Text,
            Icon = fact.Icon,
            FactType = fact.Type,
        };

        switch (fact)
        {
            case SkillFactAttributeAdjust f:
                entity.Value = f.Value;
                entity.Target = f.Target;
                break;
            case SkillFactBuff f:
                entity.Status = f.Status;
                entity.FactDescription = f.Description;
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
                entity.Value = f.Value;
                break;
            case SkillFactPercent f:
                entity.Percent = f.Percent;
                break;
            case SkillFactPrefixedBuff f:
                entity.Duration = f.Duration;
                entity.Status = f.Status;
                entity.FactDescription = f.Description;
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
                entity.Value = f.Value;
                break;
            case SkillFactRecharge f:
                entity.Value = f.Value;
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
            case SkillFactNoData:
                break;
        }

        return entity;
    }

    private static SkillFact ToFactModel(SkillFactEntity entity)
    {
        SkillFact fact = entity.FactType switch
        {
            "AttributeAdjust" => new SkillFactAttributeAdjust() { Value = entity.Value ?? 0, Target = entity.Target },
            "Buff" => new SkillFactBuff() { Status = entity.Status, Description = entity.FactDescription, ApplyCount = entity.ApplyCount, Duration = entity.Duration },
            "ComboField" => new SkillFactComboField() { FieldType = entity.FieldType ?? string.Empty },
            "ComboFinisher" => new SkillFactComboFinisher() { FinisherType = entity.FinisherType ?? string.Empty, Percent = entity.Percent ?? 0 },
            "Damage" => new SkillFactDamage() { HitCount = entity.HitCount ?? 0, DamageMultiplier = (float)(entity.DamageMultiplier ?? 0) },
            "Distance" => new SkillFactDistance() { Distance = entity.Distance ?? 0 },
            "Duration" => new SkillFactDuration() { Duration = entity.Duration ?? 0 },
            "Heal" => new SkillFactHeal() { HitCount = entity.HitCount ?? 0 },
            "HealingAdjust" => new SkillFactHealingAdjust() { HitCount = entity.HitCount ?? 0 },
            "Number" => new SkillFactNumber() { Value = entity.Value ?? 0 },
            "Percent" => new SkillFactPercent() { Percent = entity.Percent ?? 0 },
            "PrefixedBuff" => new SkillFactPrefixedBuff()
            {
                Duration = entity.Duration ?? 0,
                Status = entity.Status,
                Description = entity.FactDescription,
                ApplyCount = entity.ApplyCount ?? 0,
                Prefix = entity.PrefixText is null && entity.PrefixIcon is null && entity.PrefixStatus is null && entity.PrefixDescription is null
                    ? null
                    : new SkillFactPrefix() { Text = entity.PrefixText, Icon = entity.PrefixIcon, Status = entity.PrefixStatus, Description = entity.PrefixDescription },
            },
            "Radius" => new SkillFactRadius() { Distance = entity.Distance ?? 0 },
            "Range" => new SkillFactRange() { Value = entity.Value ?? 0 },
            "Recharge" => new SkillFactRecharge() { Value = entity.Value ?? 0 },
            "StunBreak" => new SkillFactStunBreak() { Value = entity.BoolValue ?? false },
            "Time" => new SkillFactTime() { Duration = entity.Duration ?? 0 },
            "Unblockable" => new SkillFactUnblockable() { Value = entity.BoolValue ?? false },
            "NoData" => new SkillFactNoData(),
            _ => new SkillFact(),
        };

        return fact with { Text = entity.Text, Icon = entity.Icon, Type = entity.FactType };
    }

    public static JsonElement ToFactJsonElement(SkillFactEntity entity)
    {
        var fact = ToFactModel(entity);
        return JsonSerializer.SerializeToElement(fact, fact.GetType());
    }

    public static Skill ToModel(
        SkillEntity entity,
        IEnumerable<string> professions,
        IEnumerable<string> categories,
        IEnumerable<string> flags,
        IEnumerable<SkillRelatedSkillEntity> relatedSkills,
        IEnumerable<SkillFactEntity> facts)
    {
        var related = relatedSkills.ToList();
        var factList = facts.ToList();
        return new Skill()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Icon = entity.Icon,
            ChatLink = entity.ChatLink,
            Type = entity.Type,
            WeaponType = entity.WeaponType,
            Professions = professions.ToArray(),
            Slot = entity.Slot,
            Facts = factList.Where(f => f.Kind == "Base").OrderBy(f => f.OrderIndex).Select(ToFactJsonElement).ToArray(),
            TraitedFacts = factList.Where(f => f.Kind == "Traited").OrderBy(f => f.OrderIndex).Select(ToFactJsonElement).ToArray(),
            Categories = categories.ToArray(),
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
            Flags = flags.ToArray(),
            Specialization = entity.Specialization,
        };
    }
}
