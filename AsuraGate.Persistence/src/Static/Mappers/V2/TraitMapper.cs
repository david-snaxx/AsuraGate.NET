using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class TraitMapper
{
    public static TraitEntity ToEntity(Trait model) => new TraitEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Trait? ToModel(TraitEntity entity) => MapperUtils.DeserializeJson<Trait>(entity.Data);
}
