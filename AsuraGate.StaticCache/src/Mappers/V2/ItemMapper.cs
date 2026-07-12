using System.Text.Json;
using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class ItemMapper
{
    public static ItemEntity ToItemEntity(Item item) => new ItemEntity()
    {
        Id = item.Id,
        Name = item.Name,
        Description = item.Description,
        Type = item.Type,
        Rarity = item.Rarity,
        Level = item.Level,
        VendorValue = item.VendorValue,
        DefaultSkin = item.DefaultSkin,
        ChatLink = item.ChatLink,
        Icon = item.Icon
    };

    public static IEnumerable<ItemFlagEntity> ToFlagEntities(Item item) =>
        item.Flags.Select(flag => new ItemFlagEntity() { ItemId = item.Id, Flag = flag });

    public static IEnumerable<ItemGameTypeEntity> ToGameTypeEntities(Item item) =>
        item.GameTypes.Select(gameType => new ItemGameTypeEntity() { ItemId = item.Id, GameType = gameType });

    public static IEnumerable<ItemRestrictionEntity> ToRestrictionEntities(Item item) =>
        item.Restrictions.Select(restriction => new ItemRestrictionEntity() { ItemId = item.Id, Restriction = restriction });

    public static IEnumerable<ItemUpgradePathEntity> ToUpgradePathEntities(Item item)
    {
        var into = item.UpgradesInto.Select(upgrade => new ItemUpgradePathEntity()
        {
            ItemId = item.Id,
            IsInto = true,
            Upgrade = upgrade.Upgrade,
            TargetItemId = upgrade.ItemId
        });

        var from = item.UpgradesFrom.Select(upgrade => new ItemUpgradePathEntity()
        {
            ItemId = item.Id,
            IsInto = false,
            Upgrade = upgrade.Upgrade,
            TargetItemId = upgrade.ItemId
        });

        return into.Concat(from);
    }

    // Shared shape across Armor/Back/Trinket/Weapon: infusion slots, attribute adjustment, infix
    // upgrade, suffix item, stat choices. Extracted per-subtype since the records don't share an
    // interface for these members.
    private static (InfusionSlot[] Slots, double AttributeAdjustment, InfixUpgrade? InfixUpgrade, int? SuffixItemId, string? SecondarySuffixItemId, int[] StatChoices)?
        GetEquipmentShape(ItemDetails? details) => details switch
        {
            ItemArmorDetails d => (d.InfusionSlots, d.AttributeAdjustment, d.InfixUpgrade, d.SuffixItemId, d.SecondarySuffixItemId, d.StatChoices),
            ItemBackDetails d => (d.InfusionSlots, d.AttributeAdjustment, d.InfixUpgrade, d.SuffixItemId, d.SecondarySuffixItemId, d.StatChoices),
            ItemTrinketDetails d => (d.InfusionSlots, d.AttributeAdjustment, d.InfixUpgrade, d.SuffixItemId, d.SecondarySuffixItemId, d.StatChoices),
            ItemWeaponDetails d => (d.InfusionSlots, d.AttributeAdjustment, d.InfixUpgrade, d.SuffixItemId, d.SecondarySuffixItemId, d.StatChoices),
            _ => null
        };

    public static ItemDetailsEntity? ToDetailsEntity(Item item)
    {
        var details = item.GetDetails();
        if (details is null)
        {
            return null;
        }

        var entity = new ItemDetailsEntity() { ItemId = item.Id };
        var equipment = GetEquipmentShape(details);
        if (equipment is not null)
        {
            entity.AttributeAdjustment = equipment.Value.AttributeAdjustment;
            entity.SuffixItemId = equipment.Value.SuffixItemId;
            entity.SecondarySuffixItemId = equipment.Value.SecondarySuffixItemId;
            entity.InfixUpgradeId = equipment.Value.InfixUpgrade?.Id;
            entity.InfixUpgradeBuffSkillId = equipment.Value.InfixUpgrade?.Buff?.SkillId;
            entity.InfixUpgradeBuffDescription = equipment.Value.InfixUpgrade?.Buff?.Description;
        }

        switch (details)
        {
            case ItemArmorDetails d:
                entity.DetailsSubtype = d.Type;
                entity.WeightClass = d.WeightClass;
                entity.Defense = d.Defense;
                break;
            case ItemBagDetails d:
                entity.Size = d.Size;
                entity.NoSellOrSort = d.NoSellOrSort;
                break;
            case ItemConsumableDetails d:
                entity.DetailsSubtype = d.Type;
                entity.ConsumableDescription = d.Description;
                entity.DurationMs = d.DurationMs;
                entity.UnlockType = d.UnlockType;
                entity.ColorId = d.ColorId;
                entity.RecipeId = d.RecipeId;
                entity.GuildUpgradeId = d.GuildUpgradeId;
                entity.ApplyCount = d.ApplyCount;
                entity.ConsumableName = d.Name;
                entity.ConsumableIcon = d.Icon;
                break;
            case ItemContainerDetails d:
                entity.DetailsSubtype = d.Type;
                break;
            case ItemGatheringDetails d:
                entity.DetailsSubtype = d.Type;
                break;
            case ItemGizmoDetails d:
                entity.DetailsSubtype = d.Type;
                entity.GuildUpgradeId = d.GuildUpgradeId;
                break;
            case ItemMiniPetDetails d:
                entity.MinipetId = d.MinipetId;
                break;
            case ItemSalvageKitDetails d:
                entity.DetailsSubtype = d.Type;
                entity.Charges = d.Charges;
                break;
            case ItemTrinketDetails d:
                entity.DetailsSubtype = d.Type;
                break;
            case ItemUpgradeComponentDetails d:
                entity.DetailsSubtype = d.Type;
                entity.Suffix = d.Suffix;
                entity.InfixUpgradeId = d.InfixUpgrade?.Id;
                entity.InfixUpgradeBuffSkillId = d.InfixUpgrade?.Buff?.SkillId;
                entity.InfixUpgradeBuffDescription = d.InfixUpgrade?.Buff?.Description;
                break;
            case ItemWeaponDetails d:
                entity.DetailsSubtype = d.Type;
                entity.DamageType = d.DamageType;
                entity.MinPower = d.MinPower;
                entity.MaxPower = d.MaxPower;
                entity.Defense = d.Defense;
                break;
        }

        return entity;
    }

    public static IEnumerable<ItemInfusionSlotEntity> ToInfusionSlotEntities(Item item)
    {
        var equipment = GetEquipmentShape(item.GetDetails());
        if (equipment is null)
        {
            return [];
        }

        return equipment.Value.Slots.Select((slot, index) => new ItemInfusionSlotEntity()
        {
            ItemId = item.Id,
            OrderIndex = index,
            SocketedItemId = slot.ItemId
        });
    }

    public static IEnumerable<ItemInfusionSlotFlagEntity> ToInfusionSlotFlagEntities(Item item)
    {
        var equipment = GetEquipmentShape(item.GetDetails());
        if (equipment is null)
        {
            return [];
        }

        return equipment.Value.Slots.SelectMany((slot, index) => slot.Flags.Select(flag => new ItemInfusionSlotFlagEntity()
        {
            ItemId = item.Id,
            SlotOrderIndex = index,
            Flag = flag
        }));
    }

    public static IEnumerable<ItemStatChoiceEntity> ToStatChoiceEntities(Item item)
    {
        var equipment = GetEquipmentShape(item.GetDetails());
        if (equipment is null)
        {
            return [];
        }

        return equipment.Value.StatChoices.Select(statId => new ItemStatChoiceEntity() { ItemId = item.Id, StatId = statId });
    }

    public static IEnumerable<ItemInfixUpgradeAttributeEntity> ToInfixUpgradeAttributeEntities(Item item)
    {
        var details = item.GetDetails();
        var infixUpgrade = details switch
        {
            ItemArmorDetails d => d.InfixUpgrade,
            ItemBackDetails d => d.InfixUpgrade,
            ItemTrinketDetails d => d.InfixUpgrade,
            ItemWeaponDetails d => d.InfixUpgrade,
            ItemUpgradeComponentDetails d => d.InfixUpgrade,
            _ => null
        };

        if (infixUpgrade is null)
        {
            return [];
        }

        return infixUpgrade.Attributes.Select(attribute => new ItemInfixUpgradeAttributeEntity()
        {
            ItemId = item.Id,
            Attribute = attribute.Attribute,
            Modifier = attribute.Modifier
        });
    }

    public static IEnumerable<ItemExtraRecipeEntity> ToExtraRecipeEntities(Item item) =>
        (item.GetDetails() as ItemConsumableDetails)?.ExtraRecipeIds.Select(recipeId => new ItemExtraRecipeEntity() { ItemId = item.Id, RecipeId = recipeId })
        ?? [];

    public static IEnumerable<ItemUnlockSkinEntity> ToUnlockSkinEntities(Item item) =>
        (item.GetDetails() as ItemConsumableDetails)?.Skins.Select(skinId => new ItemUnlockSkinEntity() { ItemId = item.Id, SkinId = skinId })
        ?? [];

    public static IEnumerable<ItemVendorEntity> ToVendorEntities(Item item) =>
        (item.GetDetails() as ItemGizmoDetails)?.VendorIds.Select(vendorId => new ItemVendorEntity() { ItemId = item.Id, VendorId = vendorId })
        ?? [];

    public static IEnumerable<ItemUpgradeComponentFlagEntity> ToUpgradeComponentFlagEntities(Item item) =>
        (item.GetDetails() as ItemUpgradeComponentDetails)?.Flags.Select(flag => new ItemUpgradeComponentFlagEntity() { ItemId = item.Id, Flag = flag })
        ?? [];

    public static IEnumerable<ItemInfusionUpgradeFlagEntity> ToInfusionUpgradeFlagEntities(Item item) =>
        (item.GetDetails() as ItemUpgradeComponentDetails)?.InfusionUpgradeFlags.Select(flag => new ItemInfusionUpgradeFlagEntity() { ItemId = item.Id, Flag = flag })
        ?? [];

    public static IEnumerable<ItemUpgradeComponentBonusEntity> ToUpgradeComponentBonusEntities(Item item) =>
        (item.GetDetails() as ItemUpgradeComponentDetails)?.Bonuses.Select((bonus, index) => new ItemUpgradeComponentBonusEntity()
        {
            ItemId = item.Id,
            OrderIndex = index,
            Bonus = bonus
        }) ?? [];

    public static Item ToModel(
        ItemEntity entity,
        IEnumerable<ItemFlagEntity> flagEntities,
        IEnumerable<ItemGameTypeEntity> gameTypeEntities,
        IEnumerable<ItemRestrictionEntity> restrictionEntities,
        IEnumerable<ItemUpgradePathEntity> upgradePathEntities,
        ItemDetailsEntity? detailsEntity,
        IEnumerable<ItemInfusionSlotEntity> infusionSlotEntities,
        IEnumerable<ItemInfusionSlotFlagEntity> infusionSlotFlagEntities,
        IEnumerable<ItemStatChoiceEntity> statChoiceEntities,
        IEnumerable<ItemInfixUpgradeAttributeEntity> infixUpgradeAttributeEntities,
        IEnumerable<ItemExtraRecipeEntity> extraRecipeEntities,
        IEnumerable<ItemUnlockSkinEntity> unlockSkinEntities,
        IEnumerable<ItemVendorEntity> vendorEntities,
        IEnumerable<ItemUpgradeComponentFlagEntity> upgradeComponentFlagEntities,
        IEnumerable<ItemInfusionUpgradeFlagEntity> infusionUpgradeFlagEntities,
        IEnumerable<ItemUpgradeComponentBonusEntity> upgradeComponentBonusEntities)
    {
        var upgradePaths = upgradePathEntities.ToList();

        return new Item()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Type = entity.Type,
            Rarity = entity.Rarity,
            Level = entity.Level,
            VendorValue = entity.VendorValue,
            DefaultSkin = entity.DefaultSkin,
            Flags = flagEntities.Select(flag => flag.Flag).ToArray(),
            GameTypes = gameTypeEntities.Select(gameType => gameType.GameType).ToArray(),
            Restrictions = restrictionEntities.Select(restriction => restriction.Restriction).ToArray(),
            ChatLink = entity.ChatLink,
            Icon = entity.Icon,
            UpgradesInto = upgradePaths.Where(path => path.IsInto).Select(path => new ItemUpgrade() { Upgrade = path.Upgrade, ItemId = path.TargetItemId }).ToArray(),
            UpgradesFrom = upgradePaths.Where(path => !path.IsInto).Select(path => new ItemUpgrade() { Upgrade = path.Upgrade, ItemId = path.TargetItemId }).ToArray(),
            Details = BuildDetailsElement(entity, detailsEntity, infusionSlotEntities, infusionSlotFlagEntities, statChoiceEntities,
                infixUpgradeAttributeEntities, extraRecipeEntities, unlockSkinEntities, vendorEntities,
                upgradeComponentFlagEntities, infusionUpgradeFlagEntities, upgradeComponentBonusEntities)
        };
    }

    private static JsonElement? BuildDetailsElement(
        ItemEntity entity,
        ItemDetailsEntity? details,
        IEnumerable<ItemInfusionSlotEntity> infusionSlotEntities,
        IEnumerable<ItemInfusionSlotFlagEntity> infusionSlotFlagEntities,
        IEnumerable<ItemStatChoiceEntity> statChoiceEntities,
        IEnumerable<ItemInfixUpgradeAttributeEntity> infixUpgradeAttributeEntities,
        IEnumerable<ItemExtraRecipeEntity> extraRecipeEntities,
        IEnumerable<ItemUnlockSkinEntity> unlockSkinEntities,
        IEnumerable<ItemVendorEntity> vendorEntities,
        IEnumerable<ItemUpgradeComponentFlagEntity> upgradeComponentFlagEntities,
        IEnumerable<ItemInfusionUpgradeFlagEntity> infusionUpgradeFlagEntities,
        IEnumerable<ItemUpgradeComponentBonusEntity> upgradeComponentBonusEntities)
    {
        if (details is null)
        {
            return null;
        }

        var slotFlags = infusionSlotFlagEntities.ToList();
        InfusionSlot[] BuildSlots() => infusionSlotEntities
            .OrderBy(slot => slot.OrderIndex)
            .Select(slot => new InfusionSlot()
            {
                Flags = slotFlags.Where(flag => flag.SlotOrderIndex == slot.OrderIndex).Select(flag => flag.Flag).ToArray(),
                ItemId = slot.SocketedItemId
            }).ToArray();

        InfixUpgrade? BuildInfixUpgrade() => details.InfixUpgradeId is null
            ? null
            : new InfixUpgrade()
            {
                Id = details.InfixUpgradeId.Value,
                Attributes = infixUpgradeAttributeEntities.Select(attribute => new AttributeBonus()
                {
                    Attribute = attribute.Attribute,
                    Modifier = attribute.Modifier
                }).ToArray(),
                Buff = details.InfixUpgradeBuffSkillId is null ? null : new InfixBuff()
                {
                    SkillId = details.InfixUpgradeBuffSkillId.Value,
                    Description = details.InfixUpgradeBuffDescription
                }
            };

        int[] StatChoices() => statChoiceEntities.Select(choice => choice.StatId).ToArray();

        ItemDetails? model = entity.Type switch
        {
            "Armor" => new ItemArmorDetails()
            {
                Type = details.DetailsSubtype,
                WeightClass = details.WeightClass!,
                Defense = details.Defense ?? 0,
                InfusionSlots = BuildSlots(),
                AttributeAdjustment = details.AttributeAdjustment ?? 0,
                InfixUpgrade = BuildInfixUpgrade(),
                SuffixItemId = details.SuffixItemId,
                SecondarySuffixItemId = details.SecondarySuffixItemId,
                StatChoices = StatChoices()
            },
            "Back" => new ItemBackDetails()
            {
                InfusionSlots = BuildSlots(),
                AttributeAdjustment = details.AttributeAdjustment ?? 0,
                InfixUpgrade = BuildInfixUpgrade(),
                SuffixItemId = details.SuffixItemId,
                SecondarySuffixItemId = details.SecondarySuffixItemId,
                StatChoices = StatChoices()
            },
            "Bag" => new ItemBagDetails()
            {
                Size = details.Size ?? 0,
                NoSellOrSort = details.NoSellOrSort ?? false
            },
            "Consumable" => new ItemConsumableDetails()
            {
                Type = details.DetailsSubtype,
                Description = details.ConsumableDescription,
                DurationMs = details.DurationMs,
                UnlockType = details.UnlockType,
                ColorId = details.ColorId,
                RecipeId = details.RecipeId,
                ExtraRecipeIds = extraRecipeEntities.Select(recipe => recipe.RecipeId).ToArray(),
                GuildUpgradeId = details.GuildUpgradeId,
                ApplyCount = details.ApplyCount,
                Name = details.ConsumableName,
                Icon = details.ConsumableIcon,
                Skins = unlockSkinEntities.Select(skin => skin.SkinId).ToArray()
            },
            "Container" => new ItemContainerDetails() { Type = details.DetailsSubtype },
            "Gathering" => new ItemGatheringDetails() { Type = details.DetailsSubtype },
            "Gizmo" => new ItemGizmoDetails()
            {
                Type = details.DetailsSubtype,
                GuildUpgradeId = details.GuildUpgradeId,
                VendorIds = vendorEntities.Select(vendor => vendor.VendorId).ToArray()
            },
            "MiniPet" => new ItemMiniPetDetails() { MinipetId = details.MinipetId ?? 0 },
            "Tool" => new ItemSalvageKitDetails() { Type = details.DetailsSubtype, Charges = details.Charges ?? 0 },
            "Trinket" => new ItemTrinketDetails()
            {
                Type = details.DetailsSubtype,
                InfusionSlots = BuildSlots(),
                AttributeAdjustment = details.AttributeAdjustment ?? 0,
                InfixUpgrade = BuildInfixUpgrade(),
                SuffixItemId = details.SuffixItemId,
                SecondarySuffixItemId = details.SecondarySuffixItemId,
                StatChoices = StatChoices()
            },
            "UpgradeComponent" => new ItemUpgradeComponentDetails()
            {
                Type = details.DetailsSubtype,
                Flags = upgradeComponentFlagEntities.Select(flag => flag.Flag).ToArray(),
                InfusionUpgradeFlags = infusionUpgradeFlagEntities.Select(flag => flag.Flag).ToArray(),
                Suffix = details.Suffix,
                InfixUpgrade = BuildInfixUpgrade(),
                Bonuses = upgradeComponentBonusEntities.OrderBy(bonus => bonus.OrderIndex).Select(bonus => bonus.Bonus).ToArray()
            },
            "Weapon" => new ItemWeaponDetails()
            {
                Type = details.DetailsSubtype,
                DamageType = details.DamageType!,
                MinPower = details.MinPower ?? 0,
                MaxPower = details.MaxPower ?? 0,
                Defense = details.Defense ?? 0,
                InfusionSlots = BuildSlots(),
                AttributeAdjustment = details.AttributeAdjustment ?? 0,
                InfixUpgrade = BuildInfixUpgrade(),
                SuffixItemId = details.SuffixItemId,
                SecondarySuffixItemId = details.SecondarySuffixItemId,
                StatChoices = StatChoices()
            },
            _ => null
        };

        return model is null ? null : JsonSerializer.SerializeToElement(model, model.GetType());
    }
}
