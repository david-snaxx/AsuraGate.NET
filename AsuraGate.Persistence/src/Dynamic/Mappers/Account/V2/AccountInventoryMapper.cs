using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountInventoryMapper
{
    public static AccountInventorySnapshotEntity ToEntity(IEnumerable<AccountSharedInventoryItem> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountSharedInventoryItem>? ToModel(AccountInventorySnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountSharedInventoryItem>>(entity.Data);
}
