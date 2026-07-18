using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterHeroPointMapper
{
    public static CharacterHeroPointSnapshotEntity ToEntity(string key, IEnumerable<string> model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<string>? ToModel(CharacterHeroPointSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<string>>(entity.Data);
}
