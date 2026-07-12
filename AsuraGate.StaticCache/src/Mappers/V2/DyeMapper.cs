using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class DyeMapper
{
    public static DyeEntity ToDyeEntity(Dye dye) => new DyeEntity()
    {
        Id = dye.Id,
        Name = dye.Name,
        BaseRgbR = dye.BaseRgb[0],
        BaseRgbG = dye.BaseRgb[1],
        BaseRgbB = dye.BaseRgb[2],

        ClothBrightness = dye.Cloth.Brightness,
        ClothContrast = dye.Cloth.Contrast,
        ClothHue = dye.Cloth.Hue,
        ClothSaturation = dye.Cloth.Saturation,
        ClothLightness = dye.Cloth.Lightness,
        ClothRgbR = dye.Cloth.Rgb[0],
        ClothRgbG = dye.Cloth.Rgb[1],
        ClothRgbB = dye.Cloth.Rgb[2],

        LeatherBrightness = dye.Leather.Brightness,
        LeatherContrast = dye.Leather.Contrast,
        LeatherHue = dye.Leather.Hue,
        LeatherSaturation = dye.Leather.Saturation,
        LeatherLightness = dye.Leather.Lightness,
        LeatherRgbR = dye.Leather.Rgb[0],
        LeatherRgbG = dye.Leather.Rgb[1],
        LeatherRgbB = dye.Leather.Rgb[2],

        MetalBrightness = dye.Metal.Brightness,
        MetalContrast = dye.Metal.Contrast,
        MetalHue = dye.Metal.Hue,
        MetalSaturation = dye.Metal.Saturation,
        MetalLightness = dye.Metal.Lightness,
        MetalRgbR = dye.Metal.Rgb[0],
        MetalRgbG = dye.Metal.Rgb[1],
        MetalRgbB = dye.Metal.Rgb[2],

        FurBrightness = dye.Fur?.Brightness,
        FurContrast = dye.Fur?.Contrast,
        FurHue = dye.Fur?.Hue,
        FurSaturation = dye.Fur?.Saturation,
        FurLightness = dye.Fur?.Lightness,
        FurRgbR = dye.Fur?.Rgb[0],
        FurRgbG = dye.Fur?.Rgb[1],
        FurRgbB = dye.Fur?.Rgb[2],

        Item = dye.Item
    };

    public static IEnumerable<DyeCategoryEntity> ToCategoryEntities(Dye dye) =>
        dye.Categories.Select(category => new DyeCategoryEntity()
        {
            DyeId = dye.Id,
            Category = category
        });

    public static Dye ToModel(DyeEntity entity, IEnumerable<DyeCategoryEntity> categoryEntities) => new Dye()
    {
        Id = entity.Id,
        Name = entity.Name,
        BaseRgb = [entity.BaseRgbR, entity.BaseRgbG, entity.BaseRgbB],
        Cloth = new ColorDetail()
        {
            Brightness = entity.ClothBrightness,
            Contrast = entity.ClothContrast,
            Hue = entity.ClothHue,
            Saturation = entity.ClothSaturation,
            Lightness = entity.ClothLightness,
            Rgb = [entity.ClothRgbR, entity.ClothRgbG, entity.ClothRgbB]
        },
        Leather = new ColorDetail()
        {
            Brightness = entity.LeatherBrightness,
            Contrast = entity.LeatherContrast,
            Hue = entity.LeatherHue,
            Saturation = entity.LeatherSaturation,
            Lightness = entity.LeatherLightness,
            Rgb = [entity.LeatherRgbR, entity.LeatherRgbG, entity.LeatherRgbB]
        },
        Metal = new ColorDetail()
        {
            Brightness = entity.MetalBrightness,
            Contrast = entity.MetalContrast,
            Hue = entity.MetalHue,
            Saturation = entity.MetalSaturation,
            Lightness = entity.MetalLightness,
            Rgb = [entity.MetalRgbR, entity.MetalRgbG, entity.MetalRgbB]
        },
        Fur = entity.FurBrightness is null ? null : new ColorDetail()
        {
            Brightness = entity.FurBrightness.Value,
            Contrast = entity.FurContrast!.Value,
            Hue = entity.FurHue!.Value,
            Saturation = entity.FurSaturation!.Value,
            Lightness = entity.FurLightness!.Value,
            Rgb = [entity.FurRgbR!.Value, entity.FurRgbG!.Value, entity.FurRgbB!.Value]
        },
        Item = entity.Item,
        Categories = categoryEntities.Select(category => category.Category).ToArray()
    };
}
