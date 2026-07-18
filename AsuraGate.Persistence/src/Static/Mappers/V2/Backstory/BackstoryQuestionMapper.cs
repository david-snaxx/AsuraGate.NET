using AsuraGate.Persistence.Static.Entities.V2.Backstory;
using AsuraGate.Spec.Models.V2.Backstory;

namespace AsuraGate.Persistence.Static.Mappers.V2.Backstory;

public static class BackstoryQuestionMapper
{
    public static BackstoryQuestionEntity ToEntity(BackstoryQuestion model) => new BackstoryQuestionEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static BackstoryQuestion? ToModel(BackstoryQuestionEntity entity) => MapperUtils.DeserializeJson<BackstoryQuestion>(entity.Data);
}
