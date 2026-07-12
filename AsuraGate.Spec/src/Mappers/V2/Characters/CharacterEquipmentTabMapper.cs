using AsuraGate.Spec.Entities.V2.Characters;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Spec.Mappers.V2.Characters;

public static class CharacterEquipmentTabMapper
{
    public static CharacterEquipmentTabEntity ToEntity(string characterName, CharacterEquipmentTab tab) => new CharacterEquipmentTabEntity()
    {
        CharacterName = characterName,
        Tab = tab.Tab,
        Name = tab.Name,
        IsActive = tab.IsActive,
        HasEquipmentPvp = tab.EquipmentPvp is not null,
        PvpAmulet = tab.EquipmentPvp?.Amulet,
        PvpRune = tab.EquipmentPvp?.Rune,
        HasPvpSigils = tab.EquipmentPvp?.Sigils is not null
    };

    public static IEnumerable<CharacterEquipmentTabPvpSigilEntity> ToPvpSigilEntities(string characterName, CharacterEquipmentTab tab) =>
        (tab.EquipmentPvp?.Sigils ?? []).Select((itemId, index) => new CharacterEquipmentTabPvpSigilEntity()
        {
            CharacterName = characterName,
            Tab = tab.Tab,
            OrderIndex = index,
            ItemId = itemId
        });

    public static IEnumerable<CharacterEquipmentTabItemEntity> ToItemEntities(string characterName, CharacterEquipmentTab tab) =>
        tab.Equipment.Select((item, index) => new CharacterEquipmentTabItemEntity()
        {
            CharacterName = characterName,
            Tab = tab.Tab,
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
            HasDyes = item.Dyes is not null
        });

    public static IEnumerable<CharacterEquipmentTabItemUpgradeEntity> ToUpgradeEntities(string characterName, CharacterEquipmentTab tab) =>
        tab.Equipment.SelectMany((item, itemIndex) => item.Upgrades.Select((itemId, index) => new CharacterEquipmentTabItemUpgradeEntity()
        {
            CharacterName = characterName,
            Tab = tab.Tab,
            ItemOrderIndex = itemIndex,
            OrderIndex = index,
            ItemId = itemId
        }));

    public static IEnumerable<CharacterEquipmentTabItemInfusionEntity> ToInfusionEntities(string characterName, CharacterEquipmentTab tab) =>
        tab.Equipment.SelectMany((item, itemIndex) => item.Infusions.Select((itemId, index) => new CharacterEquipmentTabItemInfusionEntity()
        {
            CharacterName = characterName,
            Tab = tab.Tab,
            ItemOrderIndex = itemIndex,
            OrderIndex = index,
            ItemId = itemId
        }));

    public static IEnumerable<CharacterEquipmentTabItemDyeEntity> ToDyeEntities(string characterName, CharacterEquipmentTab tab) =>
        tab.Equipment.SelectMany((item, itemIndex) => (item.Dyes ?? []).Select((dyeId, index) => new CharacterEquipmentTabItemDyeEntity()
        {
            CharacterName = characterName,
            Tab = tab.Tab,
            ItemOrderIndex = itemIndex,
            OrderIndex = index,
            DyeId = dyeId
        }));

    public static CharacterEquipmentTab ToModel(
        CharacterEquipmentTabEntity entity,
        IEnumerable<CharacterEquipmentTabPvpSigilEntity> pvpSigilEntities,
        IEnumerable<CharacterEquipmentTabItemEntity> itemEntities,
        IEnumerable<CharacterEquipmentTabItemUpgradeEntity> upgradeEntities,
        IEnumerable<CharacterEquipmentTabItemInfusionEntity> infusionEntities,
        IEnumerable<CharacterEquipmentTabItemDyeEntity> dyeEntities)
    {
        var upgrades = upgradeEntities.ToList();
        var infusions = infusionEntities.ToList();
        var dyes = dyeEntities.ToList();

        return new CharacterEquipmentTab()
        {
            Tab = entity.Tab,
            Name = entity.Name,
            IsActive = entity.IsActive,
            Equipment = itemEntities.OrderBy(item => item.OrderIndex).Select(item => new TabEquipmentItem()
            {
                Id = item.ItemId,
                Slot = item.Slot,
                Skin = item.Skin,
                Upgrades = upgrades.Where(u => u.ItemOrderIndex == item.OrderIndex).OrderBy(u => u.OrderIndex).Select(u => u.ItemId).ToArray(),
                Infusions = infusions.Where(i => i.ItemOrderIndex == item.OrderIndex).OrderBy(i => i.OrderIndex).Select(i => i.ItemId).ToArray(),
                Binding = item.Binding,
                BoundTo = item.BoundTo,
                Location = item.Location,
                Dyes = item.HasDyes ? dyes.Where(d => d.ItemOrderIndex == item.OrderIndex).OrderBy(d => d.OrderIndex).Select(d => d.DyeId).ToArray() : null,
                Stats = item.StatsId is null ? null : new TabEquipmentStats()
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
                }
            }).ToArray(),
            EquipmentPvp = entity.HasEquipmentPvp ? new EquipmentPvp()
            {
                Amulet = entity.PvpAmulet,
                Rune = entity.PvpRune,
                Sigils = entity.HasPvpSigils ? pvpSigilEntities.OrderBy(sigil => sigil.OrderIndex).Select(sigil => sigil.ItemId).ToArray() : null
            } : null
        };
    }
}
