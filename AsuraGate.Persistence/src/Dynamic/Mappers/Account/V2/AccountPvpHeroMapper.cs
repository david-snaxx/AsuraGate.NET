using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountPvpHeroMapper
{
    public static AccountPvpHeroSnapshotEntity ToEntity(IEnumerable<int> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<int>? ToModel(AccountPvpHeroSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<int>>(entity.Data);
}
