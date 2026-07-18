using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class CurrencyMapper
{
    public static CurrencyEntity ToEntity(Currency model) => new CurrencyEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Currency? ToModel(CurrencyEntity entity) => MapperUtils.DeserializeJson<Currency>(entity.Data);
}
