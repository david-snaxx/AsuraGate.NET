using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class WorldMapper
{
    public static WorldEntity ToEntity(World model) => new WorldEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static World? ToModel(WorldEntity entity) => MapperUtils.DeserializeJson<World>(entity.Data);
}
