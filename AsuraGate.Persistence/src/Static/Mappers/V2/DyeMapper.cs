using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class DyeMapper
{
    public static DyeEntity ToEntity(Dye model) => new DyeEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Dye ToModel(DyeEntity entity) => JsonSerializer.Deserialize<Dye>(entity.Data)!;
}
