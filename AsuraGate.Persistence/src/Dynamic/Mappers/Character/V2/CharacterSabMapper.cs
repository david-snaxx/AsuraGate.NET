using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterSabMapper
{
    public static CharacterSabSnapshotEntity ToEntity(string key, CharacterSab model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterSab? ToModel(CharacterSabSnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterSab>(entity.Data);
}
