using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Mappers.V2.Wvw;

public static class WvwObjectiveMapper
{
    public static WvwObjectiveEntity ToEntity(WvwObjective model) => new WvwObjectiveEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static WvwObjective ToModel(WvwObjectiveEntity entity) => JsonSerializer.Deserialize<WvwObjective>(entity.Data)!;
}
