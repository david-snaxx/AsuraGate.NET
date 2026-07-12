using AsuraGate.Spec.Entities.V2.Account;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Spec.Mappers.V2.Account;

public static class AccountBankItemMapper
{
    public static IEnumerable<AccountBankItemEntity> ToEntities(string accountId, IReadOnlyList<AccountBankItem?> items) =>
        items.Select((item, index) => item is null ? null : new AccountBankItemEntity()
        {
            AccountId = accountId,
            SlotIndex = index,
            ItemId = item.Id,
            Count = item.Count,
            Charges = item.Charges,
            Skin = item.Skin,
            HasDyes = item.Dyes is not null,
            Binding = item.Binding,
            BoundTo = item.BoundTo,
            StatsId = item.Stats?.Id,
            StatsAgonyResistance = item.Stats?.Attributes.AgonyResistance,
            StatsBoonDuration = item.Stats?.Attributes.BoonDuration,
            StatsConditionDamage = item.Stats?.Attributes.ConditionDamage,
            StatsConditionDuration = item.Stats?.Attributes.ConditionDuration,
            StatsCritDamage = item.Stats?.Attributes.CritDamage,
            StatsHealing = item.Stats?.Attributes.Healing,
            StatsPower = item.Stats?.Attributes.Power,
            StatsPrecision = item.Stats?.Attributes.Precision,
            StatsToughness = item.Stats?.Attributes.Toughness,
            StatsVitality = item.Stats?.Attributes.Vitality
        }).Where(entity => entity is not null)!;

    public static IEnumerable<AccountBankItemDyeEntity> ToDyeEntities(string accountId, IReadOnlyList<AccountBankItem?> items) =>
        items.SelectMany((item, slotIndex) => (item?.Dyes ?? []).Select((dyeId, orderIndex) => new AccountBankItemDyeEntity()
        {
            AccountId = accountId,
            SlotIndex = slotIndex,
            OrderIndex = orderIndex,
            DyeId = dyeId
        }));

    public static IEnumerable<AccountBankItemUpgradeEntity> ToUpgradeEntities(string accountId, IReadOnlyList<AccountBankItem?> items) =>
        items.SelectMany((item, slotIndex) => (item?.Upgrades ?? []).Select((itemId, orderIndex) => new AccountBankItemUpgradeEntity()
        {
            AccountId = accountId,
            SlotIndex = slotIndex,
            OrderIndex = orderIndex,
            ItemId = itemId,
            SlotIndexOnItem = item!.UpgradeSlotIndices.Length > orderIndex ? item.UpgradeSlotIndices[orderIndex] : 0
        }));

    public static IEnumerable<AccountBankItemInfusionEntity> ToInfusionEntities(string accountId, IReadOnlyList<AccountBankItem?> items) =>
        items.SelectMany((item, slotIndex) => (item?.Infusions ?? []).Select((infusionId, orderIndex) => new AccountBankItemInfusionEntity()
        {
            AccountId = accountId,
            SlotIndex = slotIndex,
            OrderIndex = orderIndex,
            ItemId = infusionId
        }));

    public static AccountBankItem? ToModel(
        AccountBankItemEntity entity,
        IEnumerable<AccountBankItemDyeEntity> dyeEntities,
        IEnumerable<AccountBankItemUpgradeEntity> upgradeEntities,
        IEnumerable<AccountBankItemInfusionEntity> infusionEntities)
    {
        var upgrades = upgradeEntities.OrderBy(upgrade => upgrade.OrderIndex).ToList();

        return new AccountBankItem()
        {
            Id = entity.ItemId,
            Count = entity.Count,
            Charges = entity.Charges,
            Skin = entity.Skin,
            Dyes = entity.HasDyes ? dyeEntities.OrderBy(dye => dye.OrderIndex).Select(dye => dye.DyeId).ToArray() : null,
            Upgrades = upgrades.Select(upgrade => upgrade.ItemId).ToArray(),
            UpgradeSlotIndices = upgrades.Select(upgrade => upgrade.SlotIndexOnItem).ToArray(),
            Infusions = infusionEntities.OrderBy(infusion => infusion.OrderIndex).Select(infusion => infusion.ItemId).ToArray(),
            Binding = entity.Binding,
            BoundTo = entity.BoundTo,
            Stats = entity.StatsId is null ? null : new BankItemStats()
            {
                Id = entity.StatsId.Value,
                Attributes = new BankItemAttributes()
                {
                    AgonyResistance = entity.StatsAgonyResistance,
                    BoonDuration = entity.StatsBoonDuration,
                    ConditionDamage = entity.StatsConditionDamage,
                    ConditionDuration = entity.StatsConditionDuration,
                    CritDamage = entity.StatsCritDamage,
                    Healing = entity.StatsHealing,
                    Power = entity.StatsPower,
                    Precision = entity.StatsPrecision,
                    Toughness = entity.StatsToughness,
                    Vitality = entity.StatsVitality
                }
            }
        };
    }
}
