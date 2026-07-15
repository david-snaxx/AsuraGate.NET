using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class ProfessionMapper
{
    public static ProfessionEntity ToEntity(Profession model) => new ProfessionEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Profession ToModel(ProfessionEntity entity) => JsonSerializer.Deserialize<Profession>(entity.Data)!;
}
