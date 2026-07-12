using AsuraGate.Spec.Entities.V2.Account;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Spec.Mappers.V2.Account;

public static class AccountWvwDetailsMapper
{
    public static AccountWvwDetailsEntity ToEntity(string accountId, AccountWvwDetails details) => new AccountWvwDetailsEntity()
    {
        AccountId = accountId,
        TeamId = details.TeamId,
        Rank = details.Rank,
        Rating = details.Rating
    };

    public static AccountWvwDetails ToModel(AccountWvwDetailsEntity entity) => new AccountWvwDetails()
    {
        TeamId = entity.TeamId,
        Rank = entity.Rank,
        Rating = entity.Rating
    };
}
