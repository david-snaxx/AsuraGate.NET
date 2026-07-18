using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountMaterialMapper
{
    public static AccountMaterialSnapshotEntity ToEntity(IEnumerable<AccountMaterial> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountMaterial>? ToModel(AccountMaterialSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountMaterial>>(entity.Data);
}
