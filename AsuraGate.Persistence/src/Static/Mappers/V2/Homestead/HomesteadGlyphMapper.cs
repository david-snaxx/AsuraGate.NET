using AsuraGate.Persistence.Static.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Static.Mappers.V2.Homestead;

public static class HomesteadGlyphMapper
{
    public static HomesteadGlyphEntity ToEntity(HomesteadGlyph model) => new HomesteadGlyphEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static HomesteadGlyph? ToModel(HomesteadGlyphEntity entity) => MapperUtils.DeserializeJson<HomesteadGlyph>(entity.Data);
}
