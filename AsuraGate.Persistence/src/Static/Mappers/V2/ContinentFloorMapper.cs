using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class ContinentFloorMapper
{
    public static ContinentFloorEntity ToEntity(ContinentFloor model) => new ContinentFloorEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static ContinentFloor? ToModel(ContinentFloorEntity entity) => MapperUtils.DeserializeJson<ContinentFloor>(entity.Data);
}
