using AsuraGate.Persistence.Dynamic.Entities.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.V2.Account;

public static class AccountDyeMapper
{
    public static AccountDyeSnapshotEntity ToEntity(IEnumerable<int> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<int>? ToModel(AccountDyeSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<int>>(entity.Data);
}
