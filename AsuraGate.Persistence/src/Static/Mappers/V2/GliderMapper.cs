using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class GliderMapper
{
    public static GliderEntity ToEntity(Glider model) => new GliderEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Glider ToModel(GliderEntity entity) => JsonSerializer.Deserialize<Glider>(entity.Data)!;
}
