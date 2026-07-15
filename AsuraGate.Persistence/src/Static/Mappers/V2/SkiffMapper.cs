using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class SkiffMapper
{
    public static SkiffEntity ToEntity(Skiff model) => new SkiffEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Skiff ToModel(SkiffEntity entity) => JsonSerializer.Deserialize<Skiff>(entity.Data)!;
}
