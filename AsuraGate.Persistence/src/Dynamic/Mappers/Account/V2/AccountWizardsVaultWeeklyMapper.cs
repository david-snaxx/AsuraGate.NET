using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountWizardsVaultWeeklyMapper
{
    public static AccountWizardsVaultWeeklySnapshotEntity ToEntity(AccountWizardsVaultWeekly model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static AccountWizardsVaultWeekly? ToModel(AccountWizardsVaultWeeklySnapshotEntity entity) => MapperUtils.DeserializeJson<AccountWizardsVaultWeekly>(entity.Data);
}
