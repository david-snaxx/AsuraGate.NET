using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountWalletMapper
{
    public static AccountWalletSnapshotEntity ToEntity(IEnumerable<AccountCurrency> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountCurrency>? ToModel(AccountWalletSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<AccountCurrency>>(entity.Data);
}
