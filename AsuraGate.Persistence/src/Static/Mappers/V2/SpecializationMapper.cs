using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class SpecializationMapper
{
    public static SpecializationEntity ToEntity(Specialization model) => new SpecializationEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Specialization ToModel(SpecializationEntity entity) => JsonSerializer.Deserialize<Specialization>(entity.Data)!;
}
