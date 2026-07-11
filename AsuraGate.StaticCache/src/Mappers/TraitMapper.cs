using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Trait"/> to <see cref="TraitEntity"/>. Facts on the trait itself and facts on its nested
/// <see cref="TraitSkill"/>s share the same <see cref="TraitFactEntity"/> table (see that type's docs for how
/// ownership is distinguished), so callers must insert <see cref="TraitSkillEntity"/> rows first and use the
/// assigned id when mapping that skill's own facts.
/// </summary>
public static class TraitMapper
{
    public static TraitEntity ToEntity(Trait trait) => new TraitEntity()
    {
        Id = trait.Id,
        Name = trait.Name,
        Icon = trait.Icon,
        Description = trait.Description,
        SpecializationId = trait.Specialization,
        Tier = trait.Tier,
        Order = trait.Order,
        Slot = trait.Slot,
    };

    public static IReadOnlyList<TraitSkillEntity> ToSkillEntities(Trait trait) =>
        trait.Skills.Select((skill, index) => new TraitSkillEntity()
        {
            TraitId = trait.Id,
            SkillId = skill.Id,
            OrderIndex = index,
            Name = skill.Name,
            Description = skill.Description,
            Icon = skill.Icon,
        }).ToList();

    public static IReadOnlyList<TraitFactEntity> ToFactEntities(Trait trait) =>
        trait.GetFacts(string.Empty) // the `type` parameter is unused by Trait.GetFacts; it deserializes every fact regardless
            .Select((fact, index) => ToFactEntity(fact, index, traitId: trait.Id, traitSkillId: null, kind: "Base"))
            .Where(f => f is not null).Select(f => f!).ToList();

    public static IReadOnlyList<TraitFactEntity> ToSkillFactEntities(TraitSkill skill, int traitSkillId)
    {
        var baseFacts = skill.Facts.Select((fact, index) => ToFactEntity(fact, index, traitId: null, traitSkillId: traitSkillId, kind: "Base"));
        var traitedFacts = skill.TraitedFacts.Select((fact, index) => ToFactEntity(fact, index, traitId: null, traitSkillId: traitSkillId, kind: "Traited"));
        return baseFacts.Concat(traitedFacts).Where(f => f is not null).Select(f => f!).ToList();
    }

    private static TraitFactEntity? ToFactEntity(TraitFact? fact, int orderIndex, int? traitId, int? traitSkillId, string kind)
    {
        if (fact is null) return null;

        var entity = new TraitFactEntity()
        {
            TraitId = traitId,
            TraitSkillId = traitSkillId,
            Kind = kind,
            OrderIndex = orderIndex,
            Text = fact.Text,
            Icon = fact.Icon,
            FactType = fact.Type,
        };

        switch (fact)
        {
            case TraitFactAttributeAdjust f:
                entity.Value = f.Value;
                entity.Target = f.Target;
                break;
            case TraitFactBuff f:
                entity.Status = f.Status;
                entity.FactDescription = f.Description;
                entity.ApplyCount = f.ApplyCount;
                entity.Duration = f.Duration;
                break;
            case TraitFactBuffConversion f:
                entity.ConversionSource = f.Source;
                entity.ConversionPercent = f.Percent;
                entity.ConversionTarget = f.Target;
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
                entity.Value = f.Value;
                break;
            case TraitFactPercent f:
                entity.Percent = f.Percent;
                break;
            case TraitFactPrefixedBuff f:
                entity.Duration = f.Duration;
                entity.Status = f.Status;
                entity.FactDescription = f.Description;
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
                entity.Value = f.Value;
                break;
            case TraitFactRecharge f:
                entity.Value = f.Value;
                break;
            case TraitFactTime f:
                entity.Duration = f.Duration;
                break;
            case TraitFactUnblockable f:
                entity.BoolValue = f.Value;
                break;
            case TraitFactNoData:
                break;
        }

        return entity;
    }

    public static TraitFact ToFactModel(TraitFactEntity entity)
    {
        TraitFact fact = entity.FactType switch
        {
            "AttributeAdjust" => new TraitFactAttributeAdjust() { Value = entity.Value ?? 0, Target = entity.Target },
            "Buff" => new TraitFactBuff() { Status = entity.Status, Description = entity.FactDescription, ApplyCount = entity.ApplyCount, Duration = entity.Duration },
            "BuffConversion" => new TraitFactBuffConversion() { Source = entity.ConversionSource ?? string.Empty, Percent = entity.ConversionPercent ?? string.Empty, Target = entity.ConversionTarget ?? string.Empty },
            "ComboField" => new TraitFactComboField() { FieldType = entity.FieldType ?? string.Empty },
            "ComboFinisher" => new TraitFactComboFinisher() { FinisherType = entity.FinisherType ?? string.Empty, Percent = entity.Percent ?? 0 },
            "Damage" => new TraitFactDamage() { HitCount = entity.HitCount ?? 0 },
            "Distance" => new TraitFactDistance() { Distance = entity.Distance ?? 0 },
            "Number" => new TraitFactNumber() { Value = entity.Value ?? 0 },
            "Percent" => new TraitFactPercent() { Percent = entity.Percent ?? 0 },
            "PrefixedBuff" => new TraitFactPrefixedBuff()
            {
                Duration = entity.Duration ?? 0,
                Status = entity.Status,
                Description = entity.FactDescription,
                ApplyCount = entity.ApplyCount ?? 0,
                Prefix = entity.PrefixText is null && entity.PrefixIcon is null && entity.PrefixStatus is null && entity.PrefixDescription is null
                    ? null
                    : new TraitFactPrefix() { Text = entity.PrefixText, Icon = entity.PrefixIcon, Status = entity.PrefixStatus, Description = entity.PrefixDescription },
            },
            "Radius" => new TraitFactRadius() { Distance = entity.Distance ?? 0 },
            "Range" => new TraitFactRange() { Value = entity.Value ?? 0 },
            "Recharge" => new TraitFactRecharge() { Value = entity.Value ?? 0 },
            "Time" => new TraitFactTime() { Duration = entity.Duration ?? 0 },
            "Unblockable" => new TraitFactUnblockable() { Value = entity.BoolValue ?? false },
            "NoData" => new TraitFactNoData(),
            _ => new TraitFact(),
        };

        return fact with { Text = entity.Text, Icon = entity.Icon, Type = entity.FactType };
    }

    public static TraitSkill ToSkillModel(TraitSkillEntity entity, IEnumerable<TraitFactEntity> facts)
    {
        var factList = facts.ToList();
        return new TraitSkill()
        {
            Id = entity.SkillId,
            Name = entity.Name,
            Description = entity.Description,
            Icon = entity.Icon,
            Facts = factList.Where(f => f.Kind == "Base").OrderBy(f => f.OrderIndex).Select(ToFactModel).ToArray(),
            TraitedFacts = factList.Where(f => f.Kind == "Traited").OrderBy(f => f.OrderIndex).Select(ToFactModel).ToArray(),
        };
    }

    public static Trait ToModel(TraitEntity entity, IEnumerable<TraitFactEntity> facts, IEnumerable<TraitSkill> skills) => new Trait()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        Description = entity.Description,
        Specialization = entity.SpecializationId,
        Tier = entity.Tier,
        Order = entity.Order,
        Slot = entity.Slot,
        Facts = facts.Where(f => f.Kind == "Base").OrderBy(f => f.OrderIndex)
            .Select(f => System.Text.Json.JsonSerializer.SerializeToElement(ToFactModel(f), ToFactModel(f).GetType())).ToArray(),
        Skills = skills.ToArray(),
    };
}
