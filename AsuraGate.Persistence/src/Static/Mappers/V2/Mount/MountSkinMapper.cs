using AsuraGate.Persistence.Static.Entities.V2.Mount;
using AsuraGate.Spec.Models.V2.Mount;

namespace AsuraGate.Persistence.Static.Mappers.V2.Mount;

public static class MountSkinMapper
{
    public static MountSkinEntity ToEntity(MountSkin model) => new MountSkinEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static MountSkin? ToModel(MountSkinEntity entity) => MapperUtils.DeserializeJson<MountSkin>(entity.Data);
}
