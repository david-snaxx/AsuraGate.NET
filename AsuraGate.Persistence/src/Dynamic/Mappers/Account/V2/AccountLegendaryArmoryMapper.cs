using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountLegendaryArmoryMapper
{
    public static AccountLegendaryArmorySnapshotEntity ToEntity(IEnumerable<AccountLegendaryItem> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountLegendaryItem>? ToModel(AccountLegendaryArmorySnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountLegendaryItem>>(entity.Data);
}
