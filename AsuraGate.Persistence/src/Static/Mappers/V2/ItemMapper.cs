using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class ItemMapper
{
    public static ItemEntity ToEntity(Item model) => new ItemEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Item? ToModel(ItemEntity entity) => MapperUtils.DeserializeJson<Item>(entity.Data);
}
