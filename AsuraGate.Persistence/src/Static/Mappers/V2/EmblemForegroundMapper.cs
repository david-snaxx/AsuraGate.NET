using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class EmblemForegroundMapper
{
    public static EmblemForegroundEntity ToEntity(EmblemComponent model) => new EmblemForegroundEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static EmblemComponent? ToModel(EmblemForegroundEntity entity) => MapperUtils.DeserializeJson<EmblemComponent>(entity.Data);
}
