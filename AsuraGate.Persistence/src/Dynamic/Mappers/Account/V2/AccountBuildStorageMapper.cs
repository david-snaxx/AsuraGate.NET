using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountBuildStorageMapper
{
    public static AccountBuildStorageSnapshotEntity ToEntity(IEnumerable<AccountBuildStorageTemplate> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountBuildStorageTemplate>? ToModel(AccountBuildStorageSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountBuildStorageTemplate>>(entity.Data);
}
