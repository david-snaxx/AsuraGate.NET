using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountMasteryMapper
{
    public static AccountMasterySnapshotEntity ToEntity(IEnumerable<AccountMastery> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountMastery>? ToModel(AccountMasterySnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountMastery>>(entity.Data);
}
