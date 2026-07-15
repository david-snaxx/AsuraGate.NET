using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Backstory;
using AsuraGate.Spec.Models.V2.Backstory;

namespace AsuraGate.Persistence.Mappers.V2.Backstory;

public static class BackstoryQuestionMapper
{
    public static BackstoryQuestionEntity ToEntity(BackstoryQuestion model) => new BackstoryQuestionEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static BackstoryQuestion ToModel(BackstoryQuestionEntity entity) => JsonSerializer.Deserialize<BackstoryQuestion>(entity.Data)!;
}
