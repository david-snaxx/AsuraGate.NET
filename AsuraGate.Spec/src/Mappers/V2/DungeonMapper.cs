using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class DungeonMapper
{
    public static DungeonEntity ToDungeonEntity(Dungeon dungeon) => new DungeonEntity()
    {
        Id = dungeon.Id
    };

    public static IEnumerable<DungeonPathEntity> ToPathEntities(Dungeon dungeon) =>
        dungeon.Paths.Select((path, index) => new DungeonPathEntity()
        {
            DungeonId = dungeon.Id,
            OrderIndex = index,
            PathId = path.Id,
            Type = path.Type
        });

    public static Dungeon ToModel(DungeonEntity entity, IEnumerable<DungeonPathEntity> pathEntities) => new Dungeon()
    {
        Id = entity.Id,
        Paths = pathEntities.OrderBy(path => path.OrderIndex).Select(path => new DungeonPath()
        {
            Id = path.PathId,
            Type = path.Type
        }).ToArray()
    };
}
