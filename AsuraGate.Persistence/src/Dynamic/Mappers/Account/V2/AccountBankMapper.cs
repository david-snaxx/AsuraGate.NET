using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountBankMapper
{
    public static AccountBankSnapshotEntity ToEntity(IEnumerable<AccountBankItem> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountBankItem>? ToModel(AccountBankSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountBankItem>>(entity.Data);
}
