using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Dye"/>.
/// </summary>
[Table("dyes")]
public class DyeEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("base_r")]
    public int BaseR { get; set; }

    [NotNull, Column("base_g")]
    public int BaseG { get; set; }

    [NotNull, Column("base_b")]
    public int BaseB { get; set; }

    [Indexed, Column("item_id")]
    public int? ItemId { get; set; }

    [NotNull, Column("cloth_brightness")]
    public int ClothBrightness { get; set; }

    [NotNull, Column("cloth_contrast")]
    public double ClothContrast { get; set; }

    [NotNull, Indexed, Column("cloth_hue")]
    public int ClothHue { get; set; }

    [NotNull, Column("cloth_saturation")]
    public double ClothSaturation { get; set; }

    [NotNull, Column("cloth_lightness")]
    public double ClothLightness { get; set; }

    [NotNull, Column("cloth_r")]
    public int ClothR { get; set; }

    [NotNull, Column("cloth_g")]
    public int ClothG { get; set; }

    [NotNull, Column("cloth_b")]
    public int ClothB { get; set; }

    [NotNull, Column("leather_brightness")]
    public int LeatherBrightness { get; set; }

    [NotNull, Column("leather_contrast")]
    public double LeatherContrast { get; set; }

    [NotNull, Indexed, Column("leather_hue")]
    public int LeatherHue { get; set; }

    [NotNull, Column("leather_saturation")]
    public double LeatherSaturation { get; set; }

    [NotNull, Column("leather_lightness")]
    public double LeatherLightness { get; set; }

    [NotNull, Column("leather_r")]
    public int LeatherR { get; set; }

    [NotNull, Column("leather_g")]
    public int LeatherG { get; set; }

    [NotNull, Column("leather_b")]
    public int LeatherB { get; set; }

    [NotNull, Column("metal_brightness")]
    public int MetalBrightness { get; set; }

    [NotNull, Column("metal_contrast")]
    public double MetalContrast { get; set; }

    [NotNull, Indexed, Column("metal_hue")]
    public int MetalHue { get; set; }

    [NotNull, Column("metal_saturation")]
    public double MetalSaturation { get; set; }

    [NotNull, Column("metal_lightness")]
    public double MetalLightness { get; set; }

    [NotNull, Column("metal_r")]
    public int MetalR { get; set; }

    [NotNull, Column("metal_g")]
    public int MetalG { get; set; }

    [NotNull, Column("metal_b")]
    public int MetalB { get; set; }

    [Column("fur_brightness")]
    public int? FurBrightness { get; set; }

    [Column("fur_contrast")]
    public double? FurContrast { get; set; }

    [Indexed, Column("fur_hue")]
    public int? FurHue { get; set; }

    [Column("fur_saturation")]
    public double? FurSaturation { get; set; }

    [Column("fur_lightness")]
    public double? FurLightness { get; set; }

    [Column("fur_r")]
    public int? FurR { get; set; }

    [Column("fur_g")]
    public int? FurG { get; set; }

    [Column("fur_b")]
    public int? FurB { get; set; }
}
