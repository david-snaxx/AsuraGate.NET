using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="HomesteadGlyph"/> to <see cref="HomesteadGlyphEntity"/>.
/// </summary>
public static class HomesteadGlyphMapper
{
    public static HomesteadGlyphEntity ToEntity(HomesteadGlyph glyph) => new HomesteadGlyphEntity()
    {
        Id = glyph.Id,
        ItemId = glyph.ItemId,
        Slot = glyph.Slot,
    };

    public static HomesteadGlyph ToModel(HomesteadGlyphEntity entity) => new HomesteadGlyph()
    {
        Id = entity.Id,
        ItemId = entity.ItemId,
        Slot = entity.Slot,
    };
}
