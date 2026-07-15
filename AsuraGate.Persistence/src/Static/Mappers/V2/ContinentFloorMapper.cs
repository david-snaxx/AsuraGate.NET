using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class ContinentFloorMapper
{
    public static ContinentFloorEntity ToEntity(ContinentFloor model) => new ContinentFloorEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static ContinentFloor ToModel(ContinentFloorEntity entity) => JsonSerializer.Deserialize<ContinentFloor>(entity.Data)!;
}
