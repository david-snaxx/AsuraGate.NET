using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class OutfitMapper
{
    public static OutfitEntity ToEntity(Outfit model) => new OutfitEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Outfit ToModel(OutfitEntity entity) => JsonSerializer.Deserialize<Outfit>(entity.Data)!;
}
