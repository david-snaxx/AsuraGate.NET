using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountProgressionMapper
{
    public static AccountProgressionSnapshotEntity ToEntity(IEnumerable<AccountProgression> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountProgression>? ToModel(AccountProgressionSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountProgression>>(entity.Data);
}
