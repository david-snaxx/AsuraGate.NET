using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class WorldMapper
{
    public static WorldEntity ToEntity(World world) => new WorldEntity()
    {
        Id = world.Id,
        Data = JsonSerializer.Serialize(world)
    };

    public static World ToModel(WorldEntity entity) => JsonSerializer.Deserialize<World>(entity.Data)!;
}
