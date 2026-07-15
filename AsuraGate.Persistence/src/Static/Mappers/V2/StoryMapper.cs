using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class StoryMapper
{
    public static StoryEntity ToEntity(Story model) => new StoryEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Story ToModel(StoryEntity entity) => JsonSerializer.Deserialize<Story>(entity.Data)!;
}
