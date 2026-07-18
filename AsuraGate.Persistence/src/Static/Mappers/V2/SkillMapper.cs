using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class SkillMapper
{
    public static SkillEntity ToEntity(Skill model) => new SkillEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Skill? ToModel(SkillEntity entity) => MapperUtils.DeserializeJson<Skill>(entity.Data);
}
