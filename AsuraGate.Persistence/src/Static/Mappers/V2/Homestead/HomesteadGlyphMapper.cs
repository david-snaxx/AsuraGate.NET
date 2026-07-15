using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Static.Mappers.V2.Homestead;

public static class HomesteadGlyphMapper
{
    public static HomesteadGlyphEntity ToEntity(HomesteadGlyph model) => new HomesteadGlyphEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static HomesteadGlyph ToModel(HomesteadGlyphEntity entity) => JsonSerializer.Deserialize<HomesteadGlyph>(entity.Data)!;
}
