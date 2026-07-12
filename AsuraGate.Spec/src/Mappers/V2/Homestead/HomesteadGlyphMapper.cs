using AsuraGate.Spec.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Spec.Mappers.V2.Homestead;

public static class HomesteadGlyphMapper
{
    public static HomesteadGlyphEntity ToHomesteadGlyphEntity(HomesteadGlyph glyph) => new HomesteadGlyphEntity()
    {
        Id = glyph.Id,
        ItemId = glyph.ItemId,
        Slot = glyph.Slot
    };

    public static HomesteadGlyph ToModel(HomesteadGlyphEntity entity) => new HomesteadGlyph()
    {
        Id = entity.Id,
        ItemId = entity.ItemId,
        Slot = entity.Slot
    };
}
