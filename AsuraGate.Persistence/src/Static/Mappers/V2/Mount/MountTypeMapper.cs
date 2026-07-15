using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Mount;
using AsuraGate.Spec.Models.V2.Mount;

namespace AsuraGate.Persistence.Mappers.V2.Mount;

public static class MountTypeMapper
{
    public static MountTypeEntity ToEntity(MountType model) => new MountTypeEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static MountType ToModel(MountTypeEntity entity) => JsonSerializer.Deserialize<MountType>(entity.Data)!;
}
