using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class DyeMapper
{
    public static DyeEntity ToEntity(Dye model) => new DyeEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Dye? ToModel(DyeEntity entity) => MapperUtils.DeserializeJson<Dye>(entity.Data);
}
