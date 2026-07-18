using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class MasteryMapper
{
    public static MasteryEntity ToEntity(Mastery model) => new MasteryEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Mastery? ToModel(MasteryEntity entity) => MapperUtils.DeserializeJson<Mastery>(entity.Data);
}
