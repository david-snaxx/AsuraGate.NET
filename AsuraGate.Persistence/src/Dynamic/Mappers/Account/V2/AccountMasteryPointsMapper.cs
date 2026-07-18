using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountMasteryPointsMapper
{
    public static AccountMasteryPointsSnapshotEntity ToEntity(AccountMasteryPoints model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static AccountMasteryPoints? ToModel(AccountMasteryPointsSnapshotEntity entity) => MapperUtils.DeserializeJson<AccountMasteryPoints>(entity.Data);
}
