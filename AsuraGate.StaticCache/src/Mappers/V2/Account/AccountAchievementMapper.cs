using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountAchievementMapper
{
    public static AccountAchievementEntity ToEntity(string accountId, AccountAchievement achievement) => new AccountAchievementEntity()
    {
        AccountId = accountId,
        AchievementId = achievement.Id,
        Done = achievement.Done,
        HasBits = achievement.Bits is not null,
        Current = achievement.Current,
        Max = achievement.Max,
        Repeated = achievement.Repeated,
        Unlocked = achievement.Unlocked
    };

    public static IEnumerable<AccountAchievementBitEntity> ToBitEntities(string accountId, AccountAchievement achievement) =>
        (achievement.Bits ?? []).Select((bit, index) => new AccountAchievementBitEntity()
        {
            AccountId = accountId,
            AchievementId = achievement.Id,
            OrderIndex = index,
            Bit = bit
        });

    public static AccountAchievement ToModel(AccountAchievementEntity entity, IEnumerable<AccountAchievementBitEntity> bitEntities) => new AccountAchievement()
    {
        Id = entity.AchievementId,
        Done = entity.Done,
        Bits = entity.HasBits ? bitEntities.OrderBy(bit => bit.OrderIndex).Select(bit => bit.Bit).ToArray() : null,
        Current = entity.Current,
        Max = entity.Max,
        Repeated = entity.Repeated,
        Unlocked = entity.Unlocked
    };
}
