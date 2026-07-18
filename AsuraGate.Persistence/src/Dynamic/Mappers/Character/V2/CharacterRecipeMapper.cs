using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterRecipeMapper
{
    public static CharacterRecipeSnapshotEntity ToEntity(string key, IEnumerable<int> model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<int>? ToModel(CharacterRecipeSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<int>>(entity.Data);
}
