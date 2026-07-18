using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterCoreMapper
{
    public static CharacterCoreSnapshotEntity ToEntity(string key, CharacterCore model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterCore? ToModel(CharacterCoreSnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterCore>(entity.Data);
}
