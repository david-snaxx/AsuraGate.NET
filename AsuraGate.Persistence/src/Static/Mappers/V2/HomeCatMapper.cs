using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class HomeCatMapper
{
    public static HomeCatEntity ToEntity(HomeCat model) => new HomeCatEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static HomeCat ToModel(HomeCatEntity entity) => JsonSerializer.Deserialize<HomeCat>(entity.Data)!;
}
