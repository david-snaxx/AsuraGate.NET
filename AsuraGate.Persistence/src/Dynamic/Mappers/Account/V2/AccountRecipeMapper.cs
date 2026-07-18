using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountRecipeMapper
{
    public static AccountRecipeSnapshotEntity ToEntity(IEnumerable<int> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<int>? ToModel(AccountRecipeSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<int>>(entity.Data);
}
