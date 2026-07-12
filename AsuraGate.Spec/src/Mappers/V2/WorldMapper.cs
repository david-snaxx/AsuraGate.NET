using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class WorldMapper
{
    public static WorldEntity ToWorldEntity(World world) => new WorldEntity()
    {
        Id = world.Id,
        Name = world.Name,
        Population = world.Population
    };

    public static World ToModel(WorldEntity entity) => new World()
    {
        Id = entity.Id,
        Name = entity.Name,
        Population = entity.Population
    };
}
