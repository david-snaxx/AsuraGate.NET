using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class StorySeasonMapper
{
    public static StorySeasonEntity ToEntity(StorySeason model) => new StorySeasonEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static StorySeason ToModel(StorySeasonEntity entity) => JsonSerializer.Deserialize<StorySeason>(entity.Data)!;
}
