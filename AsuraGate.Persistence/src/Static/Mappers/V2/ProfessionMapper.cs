using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class ProfessionMapper
{
    public static ProfessionEntity ToEntity(Profession model) => new ProfessionEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Profession? ToModel(ProfessionEntity entity) => MapperUtils.DeserializeJson<Profession>(entity.Data);
}
