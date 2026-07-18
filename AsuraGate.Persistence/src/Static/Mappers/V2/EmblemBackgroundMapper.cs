using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class EmblemBackgroundMapper
{
    public static EmblemBackgroundEntity ToEntity(EmblemComponent model) => new EmblemBackgroundEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static EmblemComponent? ToModel(EmblemBackgroundEntity entity) => MapperUtils.DeserializeJson<EmblemComponent>(entity.Data);
}
