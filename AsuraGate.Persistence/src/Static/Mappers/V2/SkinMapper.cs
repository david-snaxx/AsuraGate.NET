using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class SkinMapper
{
    public static SkinEntity ToEntity(Skin model) => new SkinEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Skin? ToModel(SkinEntity entity) => MapperUtils.DeserializeJson<Skin>(entity.Data);
}
