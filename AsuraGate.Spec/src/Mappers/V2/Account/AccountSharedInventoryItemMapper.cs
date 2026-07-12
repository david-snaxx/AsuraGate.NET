using AsuraGate.Spec.Entities.V2.Account;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Spec.Mappers.V2.Account;

public static class AccountSharedInventoryItemMapper
{
    public static IEnumerable<AccountSharedInventoryItemEntity> ToEntities(string accountId, IReadOnlyList<AccountSharedInventoryItem?> items) =>
        items.Select((item, index) => item is null ? null : new AccountSharedInventoryItemEntity()
        {
            AccountId = accountId,
            SlotIndex = index,
            ItemId = item.Id,
            Count = item.Count,
            Charges = item.Charges,
            Skin = item.Skin,
            Binding = item.Binding
        }).Where(entity => entity is not null)!;

    public static IEnumerable<AccountSharedInventoryItemUpgradeEntity> ToUpgradeEntities(string accountId, IReadOnlyList<AccountSharedInventoryItem?> items) =>
        items.SelectMany((item, slotIndex) => (item?.Upgrades ?? []).Select((upgradeId, orderIndex) => new AccountSharedInventoryItemUpgradeEntity()
        {
            AccountId = accountId,
            SlotIndex = slotIndex,
            OrderIndex = orderIndex,
            ItemId = upgradeId
        }));

    public static IEnumerable<AccountSharedInventoryItemInfusionEntity> ToInfusionEntities(string accountId, IReadOnlyList<AccountSharedInventoryItem?> items) =>
        items.SelectMany((item, slotIndex) => (item?.Infusions ?? []).Select((infusionId, orderIndex) => new AccountSharedInventoryItemInfusionEntity()
        {
            AccountId = accountId,
            SlotIndex = slotIndex,
            OrderIndex = orderIndex,
            ItemId = infusionId
        }));

    public static AccountSharedInventoryItem? ToModel(
        AccountSharedInventoryItemEntity entity,
        IEnumerable<AccountSharedInventoryItemUpgradeEntity> upgradeEntities,
        IEnumerable<AccountSharedInventoryItemInfusionEntity> infusionEntities) => new AccountSharedInventoryItem()
    {
        Id = entity.ItemId,
        Count = entity.Count,
        Charges = entity.Charges,
        Skin = entity.Skin,
        Upgrades = upgradeEntities.OrderBy(upgrade => upgrade.OrderIndex).Select(upgrade => upgrade.ItemId).ToArray(),
        Infusions = infusionEntities.OrderBy(infusion => infusion.OrderIndex).Select(infusion => infusion.ItemId).ToArray(),
        Binding = entity.Binding
    };
}
