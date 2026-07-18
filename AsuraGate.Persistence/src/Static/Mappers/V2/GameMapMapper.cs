using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class GameMapMapper
{
    public static GameMapEntity ToEntity(GameMap model) => new GameMapEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static GameMap? ToModel(GameMapEntity entity) => MapperUtils.DeserializeJson<GameMap>(entity.Data);
}
