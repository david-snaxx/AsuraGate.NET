using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class OutfitMapper
{
    public static OutfitEntity ToEntity(Outfit model) => new OutfitEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Outfit? ToModel(OutfitEntity entity) => MapperUtils.DeserializeJson<Outfit>(entity.Data);
}
