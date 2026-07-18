using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterCraftingMapper
{
    public static CharacterCraftingSnapshotEntity ToEntity(string key, CharacterCrafting model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterCrafting? ToModel(CharacterCraftingSnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterCrafting>(entity.Data);
}
