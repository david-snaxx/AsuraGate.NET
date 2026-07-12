using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountLegendaryItemMapper
{
    public static AccountLegendaryItemEntity ToEntity(string accountId, AccountLegendaryItem item) => new AccountLegendaryItemEntity()
    {
        AccountId = accountId,
        ItemId = item.Id,
        Count = item.Count
    };

    public static AccountLegendaryItem ToModel(AccountLegendaryItemEntity entity) => new AccountLegendaryItem()
    {
        Id = entity.ItemId,
        Count = entity.Count
    };
}
