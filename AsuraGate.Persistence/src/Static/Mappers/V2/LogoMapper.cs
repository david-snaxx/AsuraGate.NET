using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class LogoMapper
{
    public static LogoEntity ToEntity(Logo model) => new LogoEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Logo? ToModel(LogoEntity entity) => MapperUtils.DeserializeJson<Logo>(entity.Data);
}
