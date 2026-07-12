using System.Text.Json;
using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class SkinMapper
{
    public static SkinEntity ToSkinEntity(Skin skin) => new SkinEntity()
    {
        Id = skin.Id,
        Name = skin.Name,
        Type = skin.Type,
        Icon = skin.Icon,
        Rarity = skin.Rarity,
        Description = skin.Description
    };

    public static IEnumerable<SkinFlagEntity> ToFlagEntities(Skin skin) =>
        skin.Flags.Select(flag => new SkinFlagEntity() { SkinId = skin.Id, Flag = flag });

    public static IEnumerable<SkinRestrictionEntity> ToRestrictionEntities(Skin skin) =>
        skin.Restrictions.Select(restriction => new SkinRestrictionEntity() { SkinId = skin.Id, Restriction = restriction });

    public static SkinDetailsEntity? ToDetailsEntity(Skin skin)
    {
        var details = skin.GetDetails();
        if (details is null)
        {
            return null;
        }

        var entity = new SkinDetailsEntity() { SkinId = skin.Id };

        switch (details)
        {
            case SkinArmorDetails d:
                entity.DetailsSubtype = d.Type;
                entity.WeightClass = d.WeightClass;
                entity.HasDyeSlots = d.DyeSlots is not null;
                entity.HasDefaultDyeSlots = d.DyeSlots?.Default is not null;
                break;
            case SkinWeaponDetails d:
                entity.DetailsSubtype = d.Type;
                entity.DamageType = d.DamageType;
                break;
            case SkinGatheringDetails d:
                entity.DetailsSubtype = d.Type;
                break;
        }

        return entity;
    }

    public static IEnumerable<SkinDefaultDyeSlotEntity> ToDefaultDyeSlotEntities(Skin skin) =>
        (skin.GetDetails() as SkinArmorDetails)?.DyeSlots?.Default?.Select((slot, index) => new SkinDefaultDyeSlotEntity()
        {
            SkinId = skin.Id,
            OrderIndex = index,
            ColorId = slot.ColorId,
            Material = slot.Material
        }) ?? [];

    public static Skin ToModel(
        SkinEntity entity,
        IEnumerable<SkinFlagEntity> flagEntities,
        IEnumerable<SkinRestrictionEntity> restrictionEntities,
        SkinDetailsEntity? detailsEntity,
        IEnumerable<SkinDefaultDyeSlotEntity> defaultDyeSlotEntities)
    {
        SkinDetails? details = detailsEntity is null ? null : entity.Type switch
        {
            "Armor" => new SkinArmorDetails()
            {
                Type = detailsEntity.DetailsSubtype ?? string.Empty,
                WeightClass = detailsEntity.WeightClass ?? string.Empty,
                DyeSlots = detailsEntity.HasDyeSlots
                    ? new SkinDyeSlot()
                    {
                        Default = detailsEntity.HasDefaultDyeSlots
                            ? defaultDyeSlotEntities.OrderBy(slot => slot.OrderIndex).Select(slot => new SkinDefaultSlot()
                            {
                                ColorId = slot.ColorId,
                                Material = slot.Material
                            }).ToArray()
                            : null
                    }
                    : null
            },
            "Weapon" => new SkinWeaponDetails() { Type = detailsEntity.DetailsSubtype ?? string.Empty, DamageType = detailsEntity.DamageType ?? string.Empty },
            "Back" => new SkinBackDetails(),
            "Gathering" => new SkinGatheringDetails() { Type = detailsEntity.DetailsSubtype ?? string.Empty },
            _ => null
        };

        return new Skin()
        {
            Id = entity.Id,
            Name = entity.Name,
            Type = entity.Type,
            Flags = flagEntities.Select(flag => flag.Flag).ToArray(),
            Restrictions = restrictionEntities.Select(restriction => restriction.Restriction).ToArray(),
            Icon = entity.Icon,
            Rarity = entity.Rarity,
            Description = entity.Description,
            Details = details is null ? null : JsonSerializer.SerializeToElement(details, details.GetType())
        };
    }
}
