using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Static.Mappers;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

public static class AccountAchievementMapper
{
    public static AccountAchievementSnapshotEntity
        ToEntity(IEnumerable<AccountAchievement> model, DateTime timestamp) => new()
    {
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<AccountAchievement>? ToModel(AccountAchievementSnapshotEntity entity) =>
        MapperUtils.DeserializeJson<IEnumerable<AccountAchievement>>(entity.Data);
}