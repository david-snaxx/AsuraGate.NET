using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class StoryMapper
{
    public static StoryEntity ToEntity(Story model) => new StoryEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Story? ToModel(StoryEntity entity) => MapperUtils.DeserializeJson<Story>(entity.Data);
}
