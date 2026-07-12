using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Dye"/>. The four <c>ColorDetail</c> material
/// variants (cloth/leather/metal/fur) are flattened onto this row with a column prefix per material
/// instead of a child table, since each dye has at most one of each - they're fixed fields, not a list.
/// </summary>
[Table("dyes")]
public class DyeEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("base_rgb_r")]
    public int BaseRgbR { get; set; }

    [NotNull]
    [Column("base_rgb_g")]
    public int BaseRgbG { get; set; }

    [NotNull]
    [Column("base_rgb_b")]
    public int BaseRgbB { get; set; }

    [NotNull]
    [Column("cloth_brightness")]
    public int ClothBrightness { get; set; }

    [NotNull]
    [Column("cloth_contrast")]
    public double ClothContrast { get; set; }

    [NotNull]
    [Column("cloth_hue")]
    public int ClothHue { get; set; }

    [NotNull]
    [Column("cloth_saturation")]
    public double ClothSaturation { get; set; }

    [NotNull]
    [Column("cloth_lightness")]
    public double ClothLightness { get; set; }

    [NotNull]
    [Column("cloth_rgb_r")]
    public int ClothRgbR { get; set; }

    [NotNull]
    [Column("cloth_rgb_g")]
    public int ClothRgbG { get; set; }

    [NotNull]
    [Column("cloth_rgb_b")]
    public int ClothRgbB { get; set; }

    [NotNull]
    [Column("leather_brightness")]
    public int LeatherBrightness { get; set; }

    [NotNull]
    [Column("leather_contrast")]
    public double LeatherContrast { get; set; }

    [NotNull]
    [Column("leather_hue")]
    public int LeatherHue { get; set; }

    [NotNull]
    [Column("leather_saturation")]
    public double LeatherSaturation { get; set; }

    [NotNull]
    [Column("leather_lightness")]
    public double LeatherLightness { get; set; }

    [NotNull]
    [Column("leather_rgb_r")]
    public int LeatherRgbR { get; set; }

    [NotNull]
    [Column("leather_rgb_g")]
    public int LeatherRgbG { get; set; }

    [NotNull]
    [Column("leather_rgb_b")]
    public int LeatherRgbB { get; set; }

    [NotNull]
    [Column("metal_brightness")]
    public int MetalBrightness { get; set; }

    [NotNull]
    [Column("metal_contrast")]
    public double MetalContrast { get; set; }

    [NotNull]
    [Column("metal_hue")]
    public int MetalHue { get; set; }

    [NotNull]
    [Column("metal_saturation")]
    public double MetalSaturation { get; set; }

    [NotNull]
    [Column("metal_lightness")]
    public double MetalLightness { get; set; }

    [NotNull]
    [Column("metal_rgb_r")]
    public int MetalRgbR { get; set; }

    [NotNull]
    [Column("metal_rgb_g")]
    public int MetalRgbG { get; set; }

    [NotNull]
    [Column("metal_rgb_b")]
    public int MetalRgbB { get; set; }

    // Fur is optional (not every dye has a fur variant), unlike cloth/leather/metal which are always present.
    [Column("fur_brightness")]
    public int? FurBrightness { get; set; }

    [Column("fur_contrast")]
    public double? FurContrast { get; set; }

    [Column("fur_hue")]
    public int? FurHue { get; set; }

    [Column("fur_saturation")]
    public double? FurSaturation { get; set; }

    [Column("fur_lightness")]
    public double? FurLightness { get; set; }

    [Column("fur_rgb_r")]
    public int? FurRgbR { get; set; }

    [Column("fur_rgb_g")]
    public int? FurRgbG { get; set; }

    [Column("fur_rgb_b")]
    public int? FurRgbB { get; set; }

    [Column("item")]
    public int? Item { get; set; }
}

/// <summary>Category label on a <see cref="DyeEntity"/>.</summary>
[Table("dye_categories")]
public class DyeCategoryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("dye_id")]
    public int DyeId { get; set; }

    [NotNull]
    [Column("category")]
    public string Category { get; set; } = string.Empty;
}
