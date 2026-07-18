using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountFinisherMapper
{
    public static AccountFinisherSnapshotEntity ToEntity(IEnumerable<AccountFinisher> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountFinisher>? ToModel(AccountFinisherSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountFinisher>>(entity.Data);
}
