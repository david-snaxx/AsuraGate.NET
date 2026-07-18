using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterBuildTabMapper
{
    public static CharacterBuildTabSnapshotEntity ToEntity(string key, IEnumerable<CharacterBuildTab> model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<CharacterBuildTab>? ToModel(CharacterBuildTabSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<CharacterBuildTab>>(entity.Data);
}
