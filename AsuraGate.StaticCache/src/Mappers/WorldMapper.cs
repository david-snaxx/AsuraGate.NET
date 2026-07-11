using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="World"/> to <see cref="WorldEntity"/>.
/// </summary>
public static class WorldMapper
{
    public static WorldEntity ToEntity(World world) => new WorldEntity()
    {
        Id = world.Id,
        Name = world.Name,
        Population = world.Population,
    };

    public static World ToModel(WorldEntity entity) => new World()
    {
        Id = entity.Id,
        Name = entity.Name,
        Population = entity.Population,
    };
}
