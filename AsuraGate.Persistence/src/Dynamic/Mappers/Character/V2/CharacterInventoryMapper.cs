using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterInventoryMapper
{
    public static CharacterInventorySnapshotEntity ToEntity(string key, CharacterInventory model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterInventory? ToModel(CharacterInventorySnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterInventory>(entity.Data);
}
