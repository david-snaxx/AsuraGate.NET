using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2.Backstory;
using AsuraGate.Spec.Models.V2.Backstory;

namespace AsuraGate.Persistence.Static.Mappers.V2.Backstory;

public static class BackstoryAnswerMapper
{
    public static BackstoryAnswerEntity ToEntity(BackstoryAnswer model) => new BackstoryAnswerEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static BackstoryAnswer ToModel(BackstoryAnswerEntity entity) => JsonSerializer.Deserialize<BackstoryAnswer>(entity.Data)!;
}
