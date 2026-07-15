using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class MasteryMapper
{
    public static MasteryEntity ToEntity(Mastery model) => new MasteryEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Mastery ToModel(MasteryEntity entity) => JsonSerializer.Deserialize<Mastery>(entity.Data)!;
}
