using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.ETC.Entities;

namespace AsuraGate.StaticCache.ETC.Mappers;

public class WorldMapper
{
    public static WorldEntity ToEntity(World world) => new WorldEntity()
    {
        Id = world.Id,
        Name = world.Name,
        Population = world.Population,
    };

    public static World ToModel(WorldEntity worldEntity) => new World()
    {
        Id = worldEntity.Id,
        Name = worldEntity.Name,
        Population = worldEntity.Population,
    };
}