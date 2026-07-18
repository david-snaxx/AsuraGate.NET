using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterSkillsMapper
{
    public static CharacterSkillsSnapshotEntity ToEntity(string key, CharacterSkills model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterSkills? ToModel(CharacterSkillsSnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterSkills>(entity.Data);
}
