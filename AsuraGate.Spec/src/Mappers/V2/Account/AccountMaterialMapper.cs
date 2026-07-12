using AsuraGate.Spec.Entities.V2.Account;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Spec.Mappers.V2.Account;

public static class AccountMaterialMapper
{
    public static AccountMaterialEntity ToEntity(string accountId, AccountMaterial material) => new AccountMaterialEntity()
    {
        AccountId = accountId,
        ItemId = material.Id,
        Category = material.Category,
        Binding = material.Binding,
        Count = material.Count
    };

    public static AccountMaterial ToModel(AccountMaterialEntity entity) => new AccountMaterial()
    {
        Id = entity.ItemId,
        Category = entity.Category,
        Binding = entity.Binding,
        Count = entity.Count
    };
}
