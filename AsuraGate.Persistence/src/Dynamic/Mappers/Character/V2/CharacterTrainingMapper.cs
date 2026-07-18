using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterTrainingMapper
{
    public static CharacterTrainingSnapshotEntity ToEntity(string key, CharacterTraining model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterTraining? ToModel(CharacterTrainingSnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterTraining>(entity.Data);
}
