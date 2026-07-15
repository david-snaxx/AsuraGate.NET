using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class ContinentMapper
{
    public static ContinentEntity ToEntity(Continent model) => new ContinentEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Continent ToModel(ContinentEntity entity) => JsonSerializer.Deserialize<Continent>(entity.Data)!;
}
