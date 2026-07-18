using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Persistence.Static.Mappers;

namespace AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

public static class CharacterEquipmentMapper
{
    public static CharacterEquipmentSnapshotEntity ToEntity(string key, CharacterEquipment model, DateTime timestamp) => new()
    {
        Key = key,
        Timestamp = timestamp,
        Data = MapperUtils.SerializeModel(model) ?? "null"
    };

    public static CharacterEquipment? ToModel(CharacterEquipmentSnapshotEntity entity) => MapperUtils.DeserializeJson<CharacterEquipment>(entity.Data);
}
