using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class EmblemComponentMapper
{
    public static EmblemComponentEntity ToEntity(EmblemComponent model) => new EmblemComponentEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static EmblemComponent ToModel(EmblemComponentEntity entity) => JsonSerializer.Deserialize<EmblemComponent>(entity.Data)!;
}
