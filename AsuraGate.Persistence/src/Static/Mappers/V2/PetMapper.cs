using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class PetMapper
{
    public static PetEntity ToEntity(Pet model) => new PetEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Pet? ToModel(PetEntity entity) => MapperUtils.DeserializeJson<Pet>(entity.Data);
}
