using System.Text.Json;
using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Item"/> to <see cref="ItemEntity"/>. <see cref="Item.Details"/> is a raw <see cref="JsonElement"/>
/// covering 12 possible subtypes (resolved via <see cref="Item.GetDetails"/>); this mapper flattens whichever
/// subtype applies into the single wide <see cref="ItemDetailsEntity"/> row plus its shared child tables
/// (infusion slots, stat choices, infix attributes, etc.), and reconstructs the correct subtype on the way out
/// based on <see cref="ItemEntity.Type"/>.
/// </summary>
public static class ItemMapper
{
    public static ItemEntity ToEntity(Item item) => new ItemEntity()
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
        Icon = item.Icon,
    };

    public static IReadOnlyList<ItemFlagEntity> ToFlagEntities(Item item) =>
        item.Flags.Select(flag => new ItemFlagEntity() { ItemId = item.Id, Flag = flag }).ToList();

    public static IReadOnlyList<ItemGameTypeEntity> ToGameTypeEntities(Item item) =>
        item.GameTypes.Select(gameType => new ItemGameTypeEntity() { ItemId = item.Id, GameType = gameType }).ToList();

    public static IReadOnlyList<ItemRestrictionEntity> ToRestrictionEntities(Item item) =>
        item.Restrictions.Select(restriction => new ItemRestrictionEntity() { ItemId = item.Id, Restriction = restriction }).ToList();

    public static IReadOnlyList<ItemUpgradePathEntity> ToUpgradePathEntities(Item item) =>
        item.UpgradesInto.Select((upgrade, index) => new ItemUpgradePathEntity()
        {
            ItemId = item.Id,
            Direction = "Into",
            OrderIndex = index,
            Upgrade = upgrade.Upgrade,
            OtherItemId = upgrade.ItemId,
        }).Concat(item.UpgradesFrom.Select((upgrade, index) => new ItemUpgradePathEntity()
        {
            ItemId = item.Id,
            Direction = "From",
            OrderIndex = index,
            Upgrade = upgrade.Upgrade,
            OtherItemId = upgrade.ItemId,
        })).ToList();

    public static ItemUpgrade ToUpgradePathModel(ItemUpgradePathEntity entity) => new ItemUpgrade()
    {
        Upgrade = entity.Upgrade,
        ItemId = entity.OtherItemId,
    };

    /// <summary>Extracts the shared infusion slot list out of whichever <see cref="ItemDetails"/> subtype has one.</summary>
    private static InfusionSlot[] GetInfusionSlots(ItemDetails? details) => details switch
    {
        ItemArmorDetails d => d.InfusionSlots,
        ItemBackDetails d => d.InfusionSlots,
        ItemTrinketDetails d => d.InfusionSlots,
        ItemWeaponDetails d => d.InfusionSlots,
        _ => [],
    };

    /// <summary>Extracts the shared stat choice list out of whichever <see cref="ItemDetails"/> subtype has one.</summary>
    private static int[] GetStatChoices(ItemDetails? details) => details switch
    {
        ItemArmorDetails d => d.StatChoices,
        ItemBackDetails d => d.StatChoices,
        ItemTrinketDetails d => d.StatChoices,
        ItemWeaponDetails d => d.StatChoices,
        _ => [],
    };

    /// <summary>Extracts the shared infix upgrade out of whichever <see cref="ItemDetails"/> subtype has one.</summary>
    private static InfixUpgrade? GetInfixUpgrade(ItemDetails? details) => details switch
    {
        ItemArmorDetails d => d.InfixUpgrade,
        ItemBackDetails d => d.InfixUpgrade,
        ItemTrinketDetails d => d.InfixUpgrade,
        ItemWeaponDetails d => d.InfixUpgrade,
        ItemUpgradeComponentDetails d => d.InfixUpgrade,
        _ => null,
    };

    public static ItemDetailsEntity? ToDetailsEntity(Item item)
    {
        var details = item.GetDetails();
        if (details is null) return null;

        var entity = new ItemDetailsEntity()
        {
            ItemId = item.Id,
            AttributeAdjustment = details switch
            {
                ItemArmorDetails d => d.AttributeAdjustment,
                ItemBackDetails d => d.AttributeAdjustment,
                ItemTrinketDetails d => d.AttributeAdjustment,
                ItemWeaponDetails d => d.AttributeAdjustment,
                _ => null,
            },
            SuffixItemId = details switch
            {
                ItemArmorDetails d => d.SuffixItemId,
                ItemBackDetails d => d.SuffixItemId,
                ItemTrinketDetails d => d.SuffixItemId,
                ItemWeaponDetails d => d.SuffixItemId,
                _ => null,
            },
            SecondarySuffixItemId = details switch
            {
                ItemArmorDetails d => d.SecondarySuffixItemId,
                ItemBackDetails d => d.SecondarySuffixItemId,
                ItemTrinketDetails d => d.SecondarySuffixItemId,
                ItemWeaponDetails d => d.SecondarySuffixItemId,
                _ => null,
            },
        };

        var infix = GetInfixUpgrade(details);
        if (infix is not null)
        {
            entity.InfixUpgradeStatId = infix.Id;
            entity.InfixBuffSkillId = infix.Buff?.SkillId;
            entity.InfixBuffDescription = infix.Buff?.Description;
        }

        switch (details)
        {
            case ItemArmorDetails d:
                entity.SubType = d.Type;
                entity.WeightClass = d.WeightClass;
                entity.Defense = d.Defense;
                break;
            case ItemBagDetails d:
                entity.BagSize = d.Size;
                entity.NoSellOrSort = d.NoSellOrSort;
                break;
            case ItemConsumableDetails d:
                entity.SubType = d.Type;
                entity.ConsumableDescription = d.Description;
                entity.DurationMs = d.DurationMs;
                entity.UnlockType = d.UnlockType;
                entity.ColorId = d.ColorId;
                entity.RecipeId = d.RecipeId;
                entity.GuildUpgradeId = d.GuildUpgradeId;
                entity.ApplyCount = d.ApplyCount;
                entity.UnlockName = d.Name;
                entity.UnlockIcon = d.Icon;
                break;
            case ItemContainerDetails d:
                entity.SubType = d.Type;
                break;
            case ItemGatheringDetails d:
                entity.SubType = d.Type;
                break;
            case ItemGizmoDetails d:
                entity.SubType = d.Type;
                entity.GuildUpgradeId = d.GuildUpgradeId;
                break;
            case ItemMiniPetDetails d:
                entity.MinipetId = d.MinipetId;
                break;
            case ItemSalvageKitDetails d:
                entity.SubType = d.Type;
                entity.Charges = d.Charges;
                break;
            case ItemTrinketDetails d:
                entity.SubType = d.Type;
                break;
            case ItemUpgradeComponentDetails d:
                entity.SubType = d.Type;
                entity.UpgradeSuffix = d.Suffix;
                break;
            case ItemWeaponDetails d:
                entity.SubType = d.Type;
                entity.DamageType = d.DamageType;
                entity.MinPower = d.MinPower;
                entity.MaxPower = d.MaxPower;
                entity.Defense = d.Defense;
                break;
        }

        return entity;
    }

    public static IReadOnlyList<ItemInfusionSlotEntity> ToInfusionSlotEntities(Item item) =>
        GetInfusionSlots(item.GetDetails()).Select((slot, index) => new ItemInfusionSlotEntity()
        {
            ItemId = item.Id,
            OrderIndex = index,
            SocketedItemId = slot.ItemId,
        }).ToList();

    public static IReadOnlyList<ItemInfusionSlotFlagEntity> ToInfusionSlotFlagEntities(Item item, IReadOnlyList<ItemInfusionSlotEntity> persistedSlots)
    {
        var slots = GetInfusionSlots(item.GetDetails());
        var result = new List<ItemInfusionSlotFlagEntity>();
        for (var i = 0; i < slots.Length && i < persistedSlots.Count; i++)
        {
            result.AddRange(slots[i].Flags.Select(flag => new ItemInfusionSlotFlagEntity() { ItemInfusionSlotId = persistedSlots[i].Id, Flag = flag }));
        }
        return result;
    }

    public static IReadOnlyList<ItemStatChoiceEntity> ToStatChoiceEntities(Item item) =>
        GetStatChoices(item.GetDetails()).Select(statId => new ItemStatChoiceEntity() { ItemId = item.Id, StatId = statId }).ToList();

    public static IReadOnlyList<ItemInfixAttributeEntity> ToInfixAttributeEntities(Item item) =>
        (GetInfixUpgrade(item.GetDetails())?.Attributes ?? []).Select(attr => new ItemInfixAttributeEntity()
        {
            ItemId = item.Id,
            Attribute = attr.Attribute,
            Modifier = attr.Modifier,
        }).ToList();

    public static IReadOnlyList<ItemExtraRecipeEntity> ToExtraRecipeEntities(Item item) =>
        (item.GetDetails() as ItemConsumableDetails)?.ExtraRecipeIds.Select(recipeId => new ItemExtraRecipeEntity() { ItemId = item.Id, RecipeId = recipeId }).ToList()
        ?? [];

    public static IReadOnlyList<ItemConsumableSkinEntity> ToConsumableSkinEntities(Item item) =>
        (item.GetDetails() as ItemConsumableDetails)?.Skins.Select(skinId => new ItemConsumableSkinEntity() { ItemId = item.Id, SkinId = skinId }).ToList()
        ?? [];

    public static IReadOnlyList<ItemGizmoVendorIdEntity> ToGizmoVendorIdEntities(Item item) =>
        (item.GetDetails() as ItemGizmoDetails)?.VendorIds.Select(vendorId => new ItemGizmoVendorIdEntity() { ItemId = item.Id, VendorId = vendorId }).ToList()
        ?? [];

    public static IReadOnlyList<ItemUpgradeComponentFlagEntity> ToUpgradeComponentFlagEntities(Item item) =>
        (item.GetDetails() as ItemUpgradeComponentDetails)?.Flags.Select(flag => new ItemUpgradeComponentFlagEntity() { ItemId = item.Id, Flag = flag }).ToList()
        ?? [];

    public static IReadOnlyList<ItemInfusionUpgradeFlagEntity> ToInfusionUpgradeFlagEntities(Item item) =>
        (item.GetDetails() as ItemUpgradeComponentDetails)?.InfusionUpgradeFlags.Select(flag => new ItemInfusionUpgradeFlagEntity() { ItemId = item.Id, Flag = flag }).ToList()
        ?? [];

    public static IReadOnlyList<ItemUpgradeBonusEntity> ToUpgradeBonusEntities(Item item) =>
        (item.GetDetails() as ItemUpgradeComponentDetails)?.Bonuses.Select((bonus, index) => new ItemUpgradeBonusEntity() { ItemId = item.Id, OrderIndex = index, Bonus = bonus }).ToList()
        ?? [];

    /// <summary>Rebuilds the shared <see cref="InfixUpgrade"/> value object from its flattened detail columns and child attribute rows.</summary>
    private static InfixUpgrade? ToInfixUpgradeModel(ItemDetailsEntity entity, IEnumerable<AttributeBonus> attributes)
    {
        if (entity.InfixUpgradeStatId is null) return null;
        return new InfixUpgrade()
        {
            Id = entity.InfixUpgradeStatId.Value,
            Attributes = attributes.ToArray(),
            Buff = entity.InfixBuffSkillId is null ? null : new InfixBuff() { SkillId = entity.InfixBuffSkillId.Value, Description = entity.InfixBuffDescription },
        };
    }

    /// <summary>
    /// Reconstructs the <see cref="Item.Details"/> <see cref="JsonElement"/> from the flattened
    /// <see cref="ItemDetailsEntity"/> row and its child collections, based on <paramref name="itemType"/>.
    /// </summary>
    public static JsonElement? ToDetailsJsonElement(
        string itemType,
        ItemDetailsEntity? entity,
        IEnumerable<InfusionSlot> infusionSlots,
        IEnumerable<int> statChoices,
        IEnumerable<AttributeBonus> infixAttributes,
        IEnumerable<int> extraRecipeIds,
        IEnumerable<int> consumableSkins,
        IEnumerable<int> gizmoVendorIds,
        IEnumerable<string> upgradeComponentFlags,
        IEnumerable<string> infusionUpgradeFlags,
        IEnumerable<string> upgradeBonuses)
    {
        if (entity is null) return null;

        var infix = ToInfixUpgradeModel(entity, infixAttributes);
        var slots = infusionSlots.ToArray();
        var choices = statChoices.ToArray();

        ItemDetails details = itemType switch
        {
            "Armor" => new ItemArmorDetails()
            {
                Type = entity.SubType,
                WeightClass = entity.WeightClass ?? string.Empty,
                Defense = entity.Defense ?? 0,
                InfusionSlots = slots,
                AttributeAdjustment = entity.AttributeAdjustment ?? 0,
                InfixUpgrade = infix,
                SuffixItemId = entity.SuffixItemId,
                SecondarySuffixItemId = entity.SecondarySuffixItemId,
                StatChoices = choices,
            },
            "Back" => new ItemBackDetails()
            {
                InfusionSlots = slots,
                AttributeAdjustment = entity.AttributeAdjustment ?? 0,
                InfixUpgrade = infix,
                SuffixItemId = entity.SuffixItemId,
                SecondarySuffixItemId = entity.SecondarySuffixItemId,
                StatChoices = choices,
            },
            "Bag" => new ItemBagDetails() { Size = entity.BagSize ?? 0, NoSellOrSort = entity.NoSellOrSort ?? false },
            "Consumable" => new ItemConsumableDetails()
            {
                Type = entity.SubType,
                Description = entity.ConsumableDescription,
                DurationMs = entity.DurationMs,
                UnlockType = entity.UnlockType,
                ColorId = entity.ColorId,
                RecipeId = entity.RecipeId,
                ExtraRecipeIds = extraRecipeIds.ToArray(),
                GuildUpgradeId = entity.GuildUpgradeId,
                ApplyCount = entity.ApplyCount,
                Name = entity.UnlockName,
                Icon = entity.UnlockIcon,
                Skins = consumableSkins.ToArray(),
            },
            "Container" => new ItemContainerDetails() { Type = entity.SubType },
            "Gathering" => new ItemGatheringDetails() { Type = entity.SubType },
            "Gizmo" => new ItemGizmoDetails() { Type = entity.SubType, GuildUpgradeId = entity.GuildUpgradeId, VendorIds = gizmoVendorIds.ToArray() },
            "MiniPet" => new ItemMiniPetDetails() { MinipetId = entity.MinipetId ?? 0 },
            "Tool" => new ItemSalvageKitDetails() { Type = entity.SubType, Charges = entity.Charges ?? 0 },
            "Trinket" => new ItemTrinketDetails()
            {
                Type = entity.SubType,
                InfusionSlots = slots,
                AttributeAdjustment = entity.AttributeAdjustment ?? 0,
                InfixUpgrade = infix,
                SuffixItemId = entity.SuffixItemId,
                SecondarySuffixItemId = entity.SecondarySuffixItemId,
                StatChoices = choices,
            },
            "UpgradeComponent" => new ItemUpgradeComponentDetails()
            {
                Type = entity.SubType,
                Flags = upgradeComponentFlags.ToArray(),
                InfusionUpgradeFlags = infusionUpgradeFlags.ToArray(),
                Suffix = entity.UpgradeSuffix,
                InfixUpgrade = infix,
                Bonuses = upgradeBonuses.ToArray(),
            },
            "Weapon" => new ItemWeaponDetails()
            {
                Type = entity.SubType,
                DamageType = entity.DamageType ?? string.Empty,
                MinPower = entity.MinPower ?? 0,
                MaxPower = entity.MaxPower ?? 0,
                Defense = entity.Defense ?? 0,
                InfusionSlots = slots,
                AttributeAdjustment = entity.AttributeAdjustment ?? 0,
                InfixUpgrade = infix,
                SuffixItemId = entity.SuffixItemId,
                SecondarySuffixItemId = entity.SecondarySuffixItemId,
                StatChoices = choices,
            },
            _ => null!,
        };

        return details is null ? null : JsonSerializer.SerializeToElement(details, details.GetType());
    }

    public static Item ToModel(
        ItemEntity entity,
        IEnumerable<string> flags,
        IEnumerable<string> gameTypes,
        IEnumerable<string> restrictions,
        IEnumerable<ItemUpgrade> upgradesInto,
        IEnumerable<ItemUpgrade> upgradesFrom,
        JsonElement? details) => new Item()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Type = entity.Type,
        Rarity = entity.Rarity,
        Level = entity.Level,
        VendorValue = entity.VendorValue,
        DefaultSkin = entity.DefaultSkin,
        Flags = flags.ToArray(),
        GameTypes = gameTypes.ToArray(),
        Restrictions = restrictions.ToArray(),
        ChatLink = entity.ChatLink,
        Icon = entity.Icon,
        UpgradesInto = upgradesInto.ToArray(),
        UpgradesFrom = upgradesFrom.ToArray(),
        Details = details,
    };
}
