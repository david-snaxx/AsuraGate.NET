using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class DungeonMapper
{
    public static DungeonEntity ToEntity(Dungeon model) => new DungeonEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Dungeon? ToModel(DungeonEntity entity) => MapperUtils.DeserializeJson<Dungeon>(entity.Data);
}
