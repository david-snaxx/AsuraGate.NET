using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class StorySeasonMapper
{
    public static StorySeasonEntity ToEntity(StorySeason model) => new StorySeasonEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static StorySeason? ToModel(StorySeasonEntity entity) => MapperUtils.DeserializeJson<StorySeason>(entity.Data);
}
