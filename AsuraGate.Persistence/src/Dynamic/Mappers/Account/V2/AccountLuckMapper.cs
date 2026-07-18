using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountLuckMapper
{
    public static AccountLuckSnapshotEntity ToEntity(AccountLuck model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static AccountLuck? ToModel(AccountLuckSnapshotEntity entity) => MapperUtils.DeserializeJson<AccountLuck>(entity.Data);
}
