using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class ItemStatMapper
{
    public static ItemStatEntity ToEntity(ItemStat model) => new ItemStatEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static ItemStat ToModel(ItemStatEntity entity) => JsonSerializer.Deserialize<ItemStat>(entity.Data)!;
}
