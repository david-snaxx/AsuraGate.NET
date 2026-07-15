using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class LogoMapper
{
    public static LogoEntity ToEntity(Logo model) => new LogoEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Logo ToModel(LogoEntity entity) => JsonSerializer.Deserialize<Logo>(entity.Data)!;
}
