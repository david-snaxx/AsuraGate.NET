using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Mappers.V2.Achievements;

public static class AchievementGroupMapper
{
    public static AchievementGroupEntity ToEntity(AchievementGroup model) => new AchievementGroupEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static AchievementGroup ToModel(AchievementGroupEntity entity) => JsonSerializer.Deserialize<AchievementGroup>(entity.Data)!;
}
