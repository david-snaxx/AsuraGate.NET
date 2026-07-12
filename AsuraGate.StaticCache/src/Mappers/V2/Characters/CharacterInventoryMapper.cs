using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.StaticCache.Entities.V2.Characters;

namespace AsuraGate.StaticCache.Mappers.V2.Characters;

public static class CharacterInventoryMapper
{
    public static IEnumerable<CharacterInventoryBagEntity> ToBagEntities(string characterName, CharacterInventory inventory) =>
        inventory.Bags.Select((bag, index) => new CharacterInventoryBagEntity()
        {
            CharacterName = characterName,
            OrderIndex = index,
            ItemId = bag.Id,
            Size = bag.Size
        });

    public static IEnumerable<CharacterInventoryItemEntity> ToItemEntities(string characterName, CharacterInventory inventory) =>
        inventory.Bags.SelectMany((bag, bagIndex) => bag.Inventory.Select((item, slotIndex) => item is null ? null : new CharacterInventoryItemEntity()
        {
            CharacterName = characterName,
            BagOrderIndex = bagIndex,
            SlotIndex = slotIndex,
            ItemId = item.Id,
            Count = item.Count,
            Charges = item.Charges,
            Skin = item.Skin,
            HasDyes = item.Dyes is not null,
            Binding = item.Binding,
            BoundTo = item.BoundTo,
            StatsId = item.Stats?.Id,
            StatsPower = item.Stats?.Attributes.Power,
            StatsPrecision = item.Stats?.Attributes.Precision,
            StatsToughness = item.Stats?.Attributes.Toughness,
            StatsVitality = item.Stats?.Attributes.Vitality,
            StatsConditionDamage = item.Stats?.Attributes.ConditionDamage,
            StatsConditionDuration = item.Stats?.Attributes.ConditionDuration,
            StatsHealing = item.Stats?.Attributes.Healing,
            StatsBoonDuration = item.Stats?.Attributes.BoonDuration,
            StatsAgonyResistance = item.Stats?.Attributes.AgonyResistance
        }).Where(entity => entity is not null))!;

    public static IEnumerable<CharacterInventoryItemInfusionEntity> ToInfusionEntities(string characterName, CharacterInventory inventory) =>
        inventory.Bags.SelectMany((bag, bagIndex) => bag.Inventory.SelectMany((item, slotIndex) => (item?.Infusions ?? []).Select((infusionId, index) => new CharacterInventoryItemInfusionEntity()
        {
            CharacterName = characterName,
            BagOrderIndex = bagIndex,
            SlotIndex = slotIndex,
            OrderIndex = index,
            ItemId = infusionId
        })));

    public static IEnumerable<CharacterInventoryItemUpgradeEntity> ToUpgradeEntities(string characterName, CharacterInventory inventory) =>
        inventory.Bags.SelectMany((bag, bagIndex) => bag.Inventory.SelectMany((item, slotIndex) => (item?.Upgrades ?? []).Select((upgradeId, index) => new CharacterInventoryItemUpgradeEntity()
        {
            CharacterName = characterName,
            BagOrderIndex = bagIndex,
            SlotIndex = slotIndex,
            OrderIndex = index,
            ItemId = upgradeId
        })));

    public static IEnumerable<CharacterInventoryItemDyeEntity> ToDyeEntities(string characterName, CharacterInventory inventory) =>
        inventory.Bags.SelectMany((bag, bagIndex) => bag.Inventory.SelectMany((item, slotIndex) => (item?.Dyes ?? []).Select((dyeId, index) => new CharacterInventoryItemDyeEntity()
        {
            CharacterName = characterName,
            BagOrderIndex = bagIndex,
            SlotIndex = slotIndex,
            OrderIndex = index,
            DyeId = dyeId
        })));

    public static CharacterInventory ToModel(
        IEnumerable<CharacterInventoryBagEntity> bagEntities,
        IEnumerable<CharacterInventoryItemEntity> itemEntities,
        IEnumerable<CharacterInventoryItemInfusionEntity> infusionEntities,
        IEnumerable<CharacterInventoryItemUpgradeEntity> upgradeEntities,
        IEnumerable<CharacterInventoryItemDyeEntity> dyeEntities)
    {
        var items = itemEntities.ToList();
        var infusions = infusionEntities.ToList();
        var upgrades = upgradeEntities.ToList();
        var dyes = dyeEntities.ToList();

        InventoryItem? BuildItem(CharacterInventoryItemEntity item) => new InventoryItem()
        {
            Id = item.ItemId,
            Count = item.Count,
            Charges = item.Charges,
            Infusions = infusions.Where(i => i.BagOrderIndex == item.BagOrderIndex && i.SlotIndex == item.SlotIndex).OrderBy(i => i.OrderIndex).Select(i => i.ItemId).ToArray(),
            Upgrades = upgrades.Where(u => u.BagOrderIndex == item.BagOrderIndex && u.SlotIndex == item.SlotIndex).OrderBy(u => u.OrderIndex).Select(u => u.ItemId).ToArray(),
            Skin = item.Skin,
            Stats = item.StatsId is null ? null : new InventoryItemStats()
            {
                Id = item.StatsId.Value,
                Attributes = new EquipmentAttributes()
                {
                    Power = item.StatsPower,
                    Precision = item.StatsPrecision,
                    Toughness = item.StatsToughness,
                    Vitality = item.StatsVitality,
                    ConditionDamage = item.StatsConditionDamage,
                    ConditionDuration = item.StatsConditionDuration,
                    Healing = item.StatsHealing,
                    BoonDuration = item.StatsBoonDuration,
                    AgonyResistance = item.StatsAgonyResistance
                }
            },
            Dyes = item.HasDyes ? dyes.Where(d => d.BagOrderIndex == item.BagOrderIndex && d.SlotIndex == item.SlotIndex).OrderBy(d => d.OrderIndex).Select(d => d.DyeId).ToArray() : null,
            Binding = item.Binding,
            BoundTo = item.BoundTo
        };

        return new CharacterInventory()
        {
            Bags = bagEntities.OrderBy(bag => bag.OrderIndex).Select(bag =>
            {
                var slots = items.Where(item => item.BagOrderIndex == bag.OrderIndex).ToDictionary(item => item.SlotIndex);
                return new InventoryBag()
                {
                    Id = bag.ItemId,
                    Size = bag.Size,
                    Inventory = Enumerable.Range(0, bag.Size).Select(slotIndex => slots.TryGetValue(slotIndex, out var item) ? BuildItem(item) : null).ToArray()
                };
            }).ToArray()
        };
    }
}
