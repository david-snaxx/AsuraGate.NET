using System.Text.Json;
using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Skin"/> to <see cref="SkinEntity"/>.
/// </summary>
public static class SkinMapper
{
    public static SkinEntity ToEntity(Skin skin) => new SkinEntity()
    {
        Id = skin.Id,
        Name = skin.Name,
        Type = skin.Type,
        Icon = skin.Icon,
        Rarity = skin.Rarity,
        Description = skin.Description,
    };

    public static IReadOnlyList<SkinFlagEntity> ToFlagEntities(Skin skin) =>
        skin.Flags.Select(flag => new SkinFlagEntity() { SkinId = skin.Id, Flag = flag }).ToList();

    public static IReadOnlyList<SkinRestrictionEntity> ToRestrictionEntities(Skin skin) =>
        skin.Restrictions.Select(restriction => new SkinRestrictionEntity() { SkinId = skin.Id, Restriction = restriction }).ToList();

    public static SkinDetailsEntity? ToDetailsEntity(Skin skin)
    {
        var details = skin.GetDetails();
        return details switch
        {
            SkinArmorDetails d => new SkinDetailsEntity() { SkinId = skin.Id, SubType = d.Type, WeightClass = d.WeightClass },
            SkinWeaponDetails d => new SkinDetailsEntity() { SkinId = skin.Id, SubType = d.Type, DamageType = d.DamageType },
            SkinBackDetails => new SkinDetailsEntity() { SkinId = skin.Id },
            SkinGatheringDetails d => new SkinDetailsEntity() { SkinId = skin.Id, SubType = d.Type },
            _ => null,
        };
    }

    public static IReadOnlyList<SkinDyeSlotDefaultEntity> ToDyeSlotDefaultEntities(Skin skin)
    {
        if (skin.GetDetails() is not SkinArmorDetails { DyeSlots.Default: { } defaults }) return [];
        return defaults.Select((slot, index) => new SkinDyeSlotDefaultEntity()
        {
            SkinId = skin.Id,
            OrderIndex = index,
            ColorId = slot.ColorId,
            Material = slot.Material,
        }).ToList();
    }

    public static JsonElement? ToDetailsJsonElement(string skinType, SkinDetailsEntity? entity, IEnumerable<SkinDefaultSlot> dyeSlotDefaults)
    {
        if (entity is null) return null;

        SkinDetails details = skinType switch
        {
            "Armor" => new SkinArmorDetails()
            {
                Type = entity.SubType ?? string.Empty,
                WeightClass = entity.WeightClass ?? string.Empty,
                DyeSlots = new SkinDyeSlot() { Default = dyeSlotDefaults.ToArray() },
            },
            "Weapon" => new SkinWeaponDetails() { Type = entity.SubType ?? string.Empty, DamageType = entity.DamageType ?? string.Empty },
            "Back" => new SkinBackDetails(),
            "Gathering" => new SkinGatheringDetails() { Type = entity.SubType ?? string.Empty },
            _ => null!,
        };

        return details is null ? null : JsonSerializer.SerializeToElement(details, details.GetType());
    }

    public static Skin ToModel(SkinEntity entity, IEnumerable<string> flags, IEnumerable<string> restrictions, JsonElement? details) => new Skin()
    {
        Id = entity.Id,
        Name = entity.Name,
        Type = entity.Type,
        Flags = flags.ToArray(),
        Restrictions = restrictions.ToArray(),
        Icon = entity.Icon,
        Rarity = entity.Rarity,
        Description = entity.Description,
        Details = details,
    };
}
