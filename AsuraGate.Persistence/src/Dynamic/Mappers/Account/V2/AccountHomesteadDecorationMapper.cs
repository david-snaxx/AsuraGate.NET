using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountHomesteadDecorationMapper
{
    public static AccountHomesteadDecorationSnapshotEntity ToEntity(IEnumerable<AccountHomesteadDecoration> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountHomesteadDecoration>? ToModel(AccountHomesteadDecorationSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountHomesteadDecoration>>(entity.Data);
}
