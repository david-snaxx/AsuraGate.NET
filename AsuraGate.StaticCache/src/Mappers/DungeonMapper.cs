using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Dungeon"/> to <see cref="DungeonEntity"/>.
/// </summary>
public static class DungeonMapper
{
    public static DungeonEntity ToEntity(Dungeon dungeon) => new DungeonEntity()
    {
        Id = dungeon.Id,
    };

    public static IReadOnlyList<DungeonPathEntity> ToPathEntities(Dungeon dungeon) =>
        dungeon.Paths.Select(path => new DungeonPathEntity()
        {
            DungeonId = dungeon.Id,
            PathId = path.Id,
            Type = path.Type,
        }).ToList();

    public static DungeonPath ToPathModel(DungeonPathEntity entity) => new DungeonPath()
    {
        Id = entity.PathId,
        Type = entity.Type,
    };

    public static Dungeon ToModel(DungeonEntity entity, IEnumerable<DungeonPath> paths) => new Dungeon()
    {
        Id = entity.Id,
        Paths = paths.ToArray(),
    };
}
