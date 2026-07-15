using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class GameMapMapper
{
    public static GameMapEntity ToEntity(GameMap model) => new GameMapEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static GameMap ToModel(GameMapEntity entity) => JsonSerializer.Deserialize<GameMap>(entity.Data)!;
}
