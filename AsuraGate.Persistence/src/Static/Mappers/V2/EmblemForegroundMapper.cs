using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class EmblemForegroundMapper
{
    public static EmblemForegroundEntity ToEntity(EmblemComponent model) => new EmblemForegroundEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static EmblemComponent ToModel(EmblemForegroundEntity entity) => JsonSerializer.Deserialize<EmblemComponent>(entity.Data)!;
}
