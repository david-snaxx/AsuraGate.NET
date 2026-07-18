using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterBackstoryMapper
{
    public static CharacterBackstorySnapshotEntity ToEntity(string key, CharacterBackstory model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterBackstory? ToModel(CharacterBackstorySnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterBackstory>(entity.Data);
}
