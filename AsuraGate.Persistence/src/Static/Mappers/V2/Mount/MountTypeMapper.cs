using AsuraGate.Persistence.Static.Entities.V2.Mount;
using AsuraGate.Spec.Models.V2.Mount;

namespace AsuraGate.Persistence.Static.Mappers.V2.Mount;

public static class MountTypeMapper
{
    public static MountTypeEntity ToEntity(MountType model) => new MountTypeEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static MountType? ToModel(MountTypeEntity entity) => MapperUtils.DeserializeJson<MountType>(entity.Data);
}
