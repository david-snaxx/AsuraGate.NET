using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountFinisherMapper
{
    public static AccountFinisherEntity ToEntity(string accountId, AccountFinisher finisher) => new AccountFinisherEntity()
    {
        AccountId = accountId,
        FinisherId = finisher.Id,
        Permanent = finisher.Permanent,
        Quantity = finisher.Quantity
    };

    public static AccountFinisher ToModel(AccountFinisherEntity entity) => new AccountFinisher()
    {
        Id = entity.FinisherId,
        Permanent = entity.Permanent,
        Quantity = entity.Quantity
    };
}
