using AsuraGate.Spec.Entities.V2.Characters;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Spec.Mappers.V2.Characters;

public static class CharacterEquipmentMapper
{
    public static IEnumerable<CharacterEquipmentItemEntity> ToItemEntities(string characterName, CharacterEquipment equipment) =>
        equipment.Equipment.Select((item, index) => new CharacterEquipmentItemEntity()
        {
            CharacterName = characterName,
            OrderIndex = index,
            ItemId = item.Id,
            Slot = item.Slot,
            Skin = item.Skin,
            StatsId = item.Stats?.Id,
            StatsPower = item.Stats?.Attributes.Power,
            StatsPrecision = item.Stats?.Attributes.Precision,
            StatsToughness = item.Stats?.Attributes.Toughness,
            StatsVitality = item.Stats?.Attributes.Vitality,
            StatsConditionDamage = item.Stats?.Attributes.ConditionDamage,
            StatsConditionDuration = item.Stats?.Attributes.ConditionDuration,
            StatsHealing = item.Stats?.Attributes.Healing,
            StatsBoonDuration = item.Stats?.Attributes.BoonDuration,
            StatsAgonyResistance = item.Stats?.Attributes.AgonyResistance,
            Binding = item.Binding,
            BoundTo = item.BoundTo,
            Location = item.Location,
            Charges = item.Charges,
            HasDyes = item.Dyes is not null
        });

    public static IEnumerable<CharacterEquipmentItemInfusionEntity> ToInfusionEntities(string characterName, CharacterEquipment equipment) =>
        equipment.Equipment.SelectMany((item, itemIndex) => item.Infusions.Select((infusionId, index) => new CharacterEquipmentItemInfusionEntity()
        {
            CharacterName = characterName,
            ItemOrderIndex = itemIndex,
            OrderIndex = index,
            ItemId = infusionId
        }));

    public static IEnumerable<CharacterEquipmentItemUpgradeEntity> ToUpgradeEntities(string characterName, CharacterEquipment equipment) =>
        equipment.Equipment.SelectMany((item, itemIndex) => item.Upgrades.Select((upgradeId, index) => new CharacterEquipmentItemUpgradeEntity()
        {
            CharacterName = characterName,
            ItemOrderIndex = itemIndex,
            OrderIndex = index,
            ItemId = upgradeId
        }));

    public static IEnumerable<CharacterEquipmentItemDyeEntity> ToDyeEntities(string characterName, CharacterEquipment equipment) =>
        equipment.Equipment.SelectMany((item, itemIndex) => (item.Dyes ?? []).Select((dyeId, index) => new CharacterEquipmentItemDyeEntity()
        {
            CharacterName = characterName,
            ItemOrderIndex = itemIndex,
            OrderIndex = index,
            DyeId = dyeId
        }));

    public static IEnumerable<CharacterEquipmentItemTabEntity> ToTabEntities(string characterName, CharacterEquipment equipment) =>
        equipment.Equipment.SelectMany((item, itemIndex) => item.Tabs.Select((tab, index) => new CharacterEquipmentItemTabEntity()
        {
            CharacterName = characterName,
            ItemOrderIndex = itemIndex,
            OrderIndex = index,
            Tab = tab
        }));

    public static CharacterEquipment ToModel(
        IEnumerable<CharacterEquipmentItemEntity> itemEntities,
        IEnumerable<CharacterEquipmentItemInfusionEntity> infusionEntities,
        IEnumerable<CharacterEquipmentItemUpgradeEntity> upgradeEntities,
        IEnumerable<CharacterEquipmentItemDyeEntity> dyeEntities,
        IEnumerable<CharacterEquipmentItemTabEntity> tabEntities)
    {
        var infusions = infusionEntities.ToList();
        var upgrades = upgradeEntities.ToList();
        var dyes = dyeEntities.ToList();
        var tabs = tabEntities.ToList();

        return new CharacterEquipment()
        {
            Equipment = itemEntities.OrderBy(item => item.OrderIndex).Select(item => new EquipmentItem()
            {
                Id = item.ItemId,
                Slot = item.Slot,
                Infusions = infusions.Where(i => i.ItemOrderIndex == item.OrderIndex).OrderBy(i => i.OrderIndex).Select(i => i.ItemId).ToArray(),
                Upgrades = upgrades.Where(u => u.ItemOrderIndex == item.OrderIndex).OrderBy(u => u.OrderIndex).Select(u => u.ItemId).ToArray(),
                Skin = item.Skin,
                Stats = item.StatsId is null ? null : new EquipmentStats()
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
                Binding = item.Binding,
                BoundTo = item.BoundTo,
                Location = item.Location,
                Tabs = tabs.Where(t => t.ItemOrderIndex == item.OrderIndex).OrderBy(t => t.OrderIndex).Select(t => t.Tab).ToArray(),
                Charges = item.Charges,
                Dyes = item.HasDyes ? dyes.Where(d => d.ItemOrderIndex == item.OrderIndex).OrderBy(d => d.OrderIndex).Select(d => d.DyeId).ToArray() : null
            }).ToArray()
        };
    }
}
