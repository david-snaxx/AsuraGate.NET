using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class FinisherMapper
{
    public static FinisherEntity ToEntity(Finisher model) => new FinisherEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Finisher ToModel(FinisherEntity entity) => JsonSerializer.Deserialize<Finisher>(entity.Data)!;
}
