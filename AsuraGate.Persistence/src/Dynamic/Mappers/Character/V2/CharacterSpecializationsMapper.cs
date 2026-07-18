using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterSpecializationsMapper
{
    public static CharacterSpecializationsSnapshotEntity ToEntity(string key, CharacterSpecializations model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterSpecializations? ToModel(CharacterSpecializationsSnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterSpecializations>(entity.Data);
}
