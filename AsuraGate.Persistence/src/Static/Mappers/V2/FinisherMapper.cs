using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class FinisherMapper
{
    public static FinisherEntity ToEntity(Finisher model) => new FinisherEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Finisher? ToModel(FinisherEntity entity) => MapperUtils.DeserializeJson<Finisher>(entity.Data);
}
