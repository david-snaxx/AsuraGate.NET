using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Dye"/> to <see cref="DyeEntity"/>.
/// </summary>
public static class DyeMapper
{
    public static DyeEntity ToEntity(Dye dye) => new DyeEntity()
    {
        Id = dye.Id,
        Name = dye.Name,
        BaseR = dye.BaseRgb.ElementAtOrDefault(0),
        BaseG = dye.BaseRgb.ElementAtOrDefault(1),
        BaseB = dye.BaseRgb.ElementAtOrDefault(2),
        ItemId = dye.Item,
        
        ClothBrightness = dye.Cloth.Brightness,
        ClothContrast = dye.Cloth.Contrast,
        ClothHue = dye.Cloth.Hue,
        ClothSaturation = dye.Cloth.Saturation,
        ClothLightness = dye.Cloth.Lightness,
        ClothR = dye.Cloth.Rgb.ElementAtOrDefault(0),
        ClothG = dye.Cloth.Rgb.ElementAtOrDefault(1),
        ClothB = dye.Cloth.Rgb.ElementAtOrDefault(2),
        
        LeatherBrightness = dye.Leather.Brightness,
        LeatherContrast = dye.Leather.Contrast,
        LeatherHue = dye.Leather.Hue,
        LeatherSaturation = dye.Leather.Saturation,
        LeatherLightness = dye.Leather.Lightness,
        LeatherR = dye.Leather.Rgb.ElementAtOrDefault(0),
        LeatherG = dye.Leather.Rgb.ElementAtOrDefault(1),
        LeatherB = dye.Leather.Rgb.ElementAtOrDefault(2),
        
        MetalBrightness = dye.Metal.Brightness,
        MetalContrast = dye.Metal.Contrast,
        MetalHue = dye.Metal.Hue,
        MetalSaturation = dye.Metal.Saturation,
        MetalLightness = dye.Metal.Lightness,
        MetalR = dye.Metal.Rgb.ElementAtOrDefault(0),
        MetalG = dye.Metal.Rgb.ElementAtOrDefault(1),
        MetalB = dye.Metal.Rgb.ElementAtOrDefault(2),
        
        FurBrightness = dye.Fur?.Brightness,
        FurContrast = dye.Fur?.Contrast,
        FurHue = dye.Fur?.Hue,
        FurSaturation = dye.Fur?.Saturation,
        FurLightness = dye.Fur?.Lightness,
        FurR = dye.Fur?.Rgb.ElementAtOrDefault(0),
        FurG = dye.Fur?.Rgb.ElementAtOrDefault(1),
        FurB = dye.Fur?.Rgb.ElementAtOrDefault(2),
    };
    
    public static IReadOnlyList<DyeCategoryEntity> ToCategoryEntities(Dye dye) =>
        dye.Categories.Select(category => new DyeCategoryEntity { DyeId = dye.Id, Category = category }).ToList();

    public static Dye ToModel(DyeEntity entity, IEnumerable<string> categories) => new Dye()
    {
        Id = entity.Id,
        Name = entity.Name,
        BaseRgb = [entity.BaseR, entity.BaseG, entity.BaseB],
        Item = entity.ItemId,
        Categories = categories.ToArray(),
        
        Cloth = new ColorDetail()
        {
            Brightness = entity.ClothBrightness,
            Contrast = entity.ClothContrast,
            Hue = entity.ClothHue,
            Saturation = entity.ClothSaturation,
            Lightness = entity.ClothLightness,
            Rgb = [entity.ClothR, entity.ClothG, entity.ClothB]
        },
        Leather = new ColorDetail()
        {
            Brightness = entity.LeatherBrightness,
            Contrast = entity.LeatherContrast,
            Hue = entity.LeatherHue,
            Saturation = entity.LeatherSaturation,
            Lightness = entity.LeatherLightness,
            Rgb = [entity.LeatherR, entity.LeatherG, entity.LeatherB]
        },
        Metal = new ColorDetail()
        {
            Brightness = entity.MetalBrightness,
            Contrast = entity.MetalContrast,
            Hue = entity.MetalHue,
            Saturation = entity.MetalSaturation,
            Lightness = entity.MetalLightness,
            Rgb = [entity.MetalR, entity.MetalG, entity.MetalB]
        },
        Fur = entity.FurHue is null ? null : new ColorDetail()
        {
            Brightness = entity.FurBrightness!.Value,
            Contrast = entity.FurContrast!.Value,
            Hue = entity.FurHue.Value,
            Saturation = entity.FurSaturation!.Value,
            Lightness = entity.FurLightness!.Value,
            Rgb = [entity.FurR!.Value, entity.FurG!.Value, entity.FurB!.Value]
        }
    };
}