using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2.Mount;
using AsuraGate.Spec.Models.V2.Mount;

namespace AsuraGate.Persistence.Static.Mappers.V2.Mount;

public static class MountSkinMapper
{
    public static MountSkinEntity ToEntity(MountSkin model) => new MountSkinEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static MountSkin ToModel(MountSkinEntity entity) => JsonSerializer.Deserialize<MountSkin>(entity.Data)!;
}
