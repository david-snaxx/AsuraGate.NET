using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class JadeBotMapper
{
    public static JadeBotEntity ToEntity(JadeBot model) => new JadeBotEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static JadeBot? ToModel(JadeBotEntity entity) => MapperUtils.DeserializeJson<JadeBot>(entity.Data);
}
