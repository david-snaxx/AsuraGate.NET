using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Static.Mappers.V2.Achievements;

public static class AchievementMapper
{
    public static AchievementEntity ToEntity(Achievement model) => new AchievementEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Achievement ToModel(AchievementEntity entity) => JsonSerializer.Deserialize<Achievement>(entity.Data)!;
}
