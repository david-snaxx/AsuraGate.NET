using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class DungeonMapper
{
    public static DungeonEntity ToEntity(Dungeon model) => new DungeonEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Dungeon ToModel(DungeonEntity entity) => JsonSerializer.Deserialize<Dungeon>(entity.Data)!;
}
