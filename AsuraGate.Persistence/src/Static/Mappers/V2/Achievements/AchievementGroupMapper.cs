using AsuraGate.Persistence.Static.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Static.Mappers.V2.Achievements;

public static class AchievementGroupMapper
{
    public static AchievementGroupEntity ToEntity(AchievementGroup model) => new AchievementGroupEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static AchievementGroup? ToModel(AchievementGroupEntity entity) => MapperUtils.DeserializeJson<AchievementGroup>(entity.Data);
}
