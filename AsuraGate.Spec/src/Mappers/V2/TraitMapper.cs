using System.Text.Json;
using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class TraitMapper
{
    public static TraitEntity ToTraitEntity(Trait trait) => new TraitEntity()
    {
        Id = trait.Id,
        Name = trait.Name,
        Icon = trait.Icon,
        Description = trait.Description,
        Specialization = trait.Specialization,
        Tier = trait.Tier,
        Order = trait.Order,
        Slot = trait.Slot
    };

    private static TraitFactEntity ToFactEntity(int traitId, int orderIndex, TraitFact? fact)
    {
        var entity = new TraitFactEntity()
        {
            TraitId = traitId,
            OrderIndex = orderIndex,
            Text = fact?.Text,
            Icon = fact?.Icon,
            FactType = fact?.Type ?? string.Empty
        };

        switch (fact)
        {
            case TraitFactAttributeAdjust f:
                entity.ValueInt = f.Value;
                entity.Target = f.Target;
                break;
            case TraitFactBuff f:
                entity.Status = f.Status;
                entity.BuffDescription = f.Description;
                entity.ApplyCount = f.ApplyCount;
                entity.Duration = f.Duration;
                break;
            case TraitFactBuffConversion f:
                entity.Source = f.Source;
                entity.BuffConversionPercent = f.Percent;
                entity.Target = f.Target;
                break;
            case TraitFactComboField f:
                entity.FieldType = f.FieldType;
                break;
            case TraitFactComboFinisher f:
                entity.FinisherType = f.FinisherType;
                entity.Percent = f.Percent;
                break;
            case TraitFactDamage f:
                entity.HitCount = f.HitCount;
                break;
            case TraitFactDistance f:
                entity.Distance = f.Distance;
                break;
            case TraitFactNumber f:
                entity.ValueInt = f.Value;
                break;
            case TraitFactPercent f:
                entity.Percent = f.Percent;
                break;
            case TraitFactPrefixedBuff f:
                entity.Duration = f.Duration;
                entity.Status = f.Status;
                entity.BuffDescription = f.Description;
                entity.ApplyCount = f.ApplyCount;
                entity.PrefixText = f.Prefix?.Text;
                entity.PrefixIcon = f.Prefix?.Icon;
                entity.PrefixStatus = f.Prefix?.Status;
                entity.PrefixDescription = f.Prefix?.Description;
                break;
            case TraitFactRadius f:
                entity.Distance = f.Distance;
                break;
            case TraitFactRange f:
                entity.ValueInt = f.Value;
                break;
            case TraitFactRecharge f:
                entity.ValueInt = f.Value;
                break;
            case TraitFactTime f:
                entity.Duration = f.Duration;
                break;
            case TraitFactUnblockable f:
                entity.BoolValue = f.Value;
                break;
        }

        return entity;
    }

    private static TraitFact FromFactEntity(TraitFactEntity entity)
    {
        TraitFact fact = entity.FactType switch
        {
            "AttributeAdjust" => new TraitFactAttributeAdjust() { Value = entity.ValueInt ?? 0, Target = entity.Target },
            "Buff" => new TraitFactBuff() { Status = entity.Status, Description = entity.BuffDescription, ApplyCount = entity.ApplyCount, Duration = entity.Duration },
            "BuffConversion" => new TraitFactBuffConversion() { Source = entity.Source ?? string.Empty, Percent = entity.BuffConversionPercent ?? string.Empty, Target = entity.Target ?? string.Empty },
            "ComboField" => new TraitFactComboField() { FieldType = entity.FieldType ?? string.Empty },
            "ComboFinisher" => new TraitFactComboFinisher() { FinisherType = entity.FinisherType ?? string.Empty, Percent = entity.Percent ?? 0 },
            "Damage" => new TraitFactDamage() { HitCount = entity.HitCount ?? 0 },
            "Distance" => new TraitFactDistance() { Distance = entity.Distance ?? 0 },
            "NoData" => new TraitFactNoData(),
            "Number" => new TraitFactNumber() { Value = entity.ValueInt ?? 0 },
            "Percent" => new TraitFactPercent() { Percent = entity.Percent ?? 0 },
            "PrefixedBuff" => new TraitFactPrefixedBuff()
            {
                Duration = entity.Duration ?? 0,
                Status = entity.Status,
                Description = entity.BuffDescription,
                ApplyCount = entity.ApplyCount ?? 0,
                Prefix = entity.PrefixText is null && entity.PrefixIcon is null && entity.PrefixStatus is null && entity.PrefixDescription is null
                    ? null
                    : new TraitFactPrefix() { Text = entity.PrefixText, Icon = entity.PrefixIcon, Status = entity.PrefixStatus, Description = entity.PrefixDescription }
            },
            "Radius" => new TraitFactRadius() { Distance = entity.Distance ?? 0 },
            "Range" => new TraitFactRange() { Value = entity.ValueInt ?? 0 },
            "Recharge" => new TraitFactRecharge() { Value = entity.ValueInt ?? 0 },
            "Time" => new TraitFactTime() { Duration = entity.Duration ?? 0 },
            "Unblockable" => new TraitFactUnblockable() { Value = entity.BoolValue ?? false },
            _ => new TraitFact()
        };

        return fact with { Text = entity.Text, Icon = entity.Icon, Type = entity.FactType };
    }

    public static IEnumerable<TraitFactEntity> ToFactEntities(Trait trait) =>
        trait.GetFacts(string.Empty).Select((fact, index) => ToFactEntity(trait.Id, index, fact));

    public static IEnumerable<TraitSkillEntity> ToSkillEntities(Trait trait) =>
        trait.Skills.Select((skill, index) => new TraitSkillEntity()
        {
            TraitId = trait.Id,
            OrderIndex = index,
            SkillId = skill.Id,
            Name = skill.Name,
            Description = skill.Description,
            Icon = skill.Icon
        });

    private static TraitSkillFactEntity ToSkillFactEntity(int traitId, int skillId, bool isTraited, int orderIndex, TraitFact fact) => new TraitSkillFactEntity()
    {
        TraitId = traitId,
        SkillId = skillId,
        IsTraited = isTraited,
        OrderIndex = orderIndex,
        Text = fact.Text,
        Icon = fact.Icon
    };

    public static IEnumerable<TraitSkillFactEntity> ToSkillFactEntities(Trait trait) =>
        trait.Skills.SelectMany(skill =>
        {
            var baseFacts = skill.Facts.Select((fact, index) => ToSkillFactEntity(trait.Id, skill.Id, false, index, fact));
            var traitedFacts = skill.TraitedFacts.Select((fact, index) => ToSkillFactEntity(trait.Id, skill.Id, true, index, fact));
            return baseFacts.Concat(traitedFacts);
        });

    public static Trait ToModel(
        TraitEntity entity,
        IEnumerable<TraitFactEntity> factEntities,
        IEnumerable<TraitSkillEntity> skillEntities,
        IEnumerable<TraitSkillFactEntity> skillFactEntities)
    {
        var skillFacts = skillFactEntities.ToList();

        return new Trait()
        {
            Id = entity.Id,
            Name = entity.Name,
            Icon = entity.Icon,
            Description = entity.Description,
            Specialization = entity.Specialization,
            Tier = entity.Tier,
            Order = entity.Order,
            Slot = entity.Slot,
            Facts = factEntities.OrderBy(fact => fact.OrderIndex).Select(fact => JsonSerializer.SerializeToElement(FromFactEntity(fact))).ToArray(),
            Skills = skillEntities.OrderBy(skill => skill.OrderIndex).Select(skill => new TraitSkill()
            {
                Id = skill.SkillId,
                Name = skill.Name,
                Description = skill.Description,
                Icon = skill.Icon,
                Facts = skillFacts
                    .Where(fact => fact.SkillId == skill.SkillId && !fact.IsTraited)
                    .OrderBy(fact => fact.OrderIndex)
                    .Select(fact => new TraitFact() { Text = fact.Text, Icon = fact.Icon })
                    .ToArray(),
                TraitedFacts = skillFacts
                    .Where(fact => fact.SkillId == skill.SkillId && fact.IsTraited)
                    .OrderBy(fact => fact.OrderIndex)
                    .Select(fact => new TraitFact() { Text = fact.Text, Icon = fact.Icon })
                    .ToArray()
            }).ToArray()
        };
    }
}
