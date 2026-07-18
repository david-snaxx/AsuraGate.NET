using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountWizardsVaultSpecialMapper
{
    public static AccountWizardsVaultSpecialSnapshotEntity ToEntity(AccountWizardsVaultSpecial model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static AccountWizardsVaultSpecial? ToModel(AccountWizardsVaultSpecialSnapshotEntity entity) => MapperUtils.DeserializeJson<AccountWizardsVaultSpecial>(entity.Data);
}
