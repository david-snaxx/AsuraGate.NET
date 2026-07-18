using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class QuagganMapper
{
    public static QuagganEntity ToEntity(Quaggan model) => new QuagganEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Quaggan? ToModel(QuagganEntity entity) => MapperUtils.DeserializeJson<Quaggan>(entity.Data);
}
