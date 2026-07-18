using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountMountTypeMapper
{
    public static AccountMountTypeSnapshotEntity ToEntity(IEnumerable<string> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<string>? ToModel(AccountMountTypeSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<string>>(entity.Data);
}
