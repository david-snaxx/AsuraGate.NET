using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterEquipmentTabMapper
{
    public static CharacterEquipmentTabSnapshotEntity ToEntity(string key, IEnumerable<CharacterEquipmentTab> model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "[]"
    };

    public static IEnumerable<CharacterEquipmentTab>? ToModel(CharacterEquipmentTabSnapshotEntity entity) => MapperUtils.DeserializeJson<IEnumerable<CharacterEquipmentTab>>(entity.Data);
}
