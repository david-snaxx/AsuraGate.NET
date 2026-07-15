using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Static.Mappers.V2.Achievements;

public static class AchievementCategoryMapper
{
    public static AchievementCategoryEntity ToEntity(AchievementCategory model) => new AchievementCategoryEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static AchievementCategory ToModel(AchievementCategoryEntity entity) => JsonSerializer.Deserialize<AchievementCategory>(entity.Data)!;
}
