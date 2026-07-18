using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class SpecializationMapper
{
    public static SpecializationEntity ToEntity(Specialization model) => new SpecializationEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Specialization? ToModel(SpecializationEntity entity) => MapperUtils.DeserializeJson<Specialization>(entity.Data);
}
