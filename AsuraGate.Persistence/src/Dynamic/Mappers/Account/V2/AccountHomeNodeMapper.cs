using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountHomeNodeMapper
{
    public static AccountHomeNodeSnapshotEntity ToEntity(IEnumerable<string> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<string>? ToModel(AccountHomeNodeSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<string>>(entity.Data);
}
