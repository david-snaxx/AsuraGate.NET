using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;
using AsuraGate.StaticCache.Mappers;
using SQLite;

namespace AsuraGate.StaticCache.Repositories;

public static class DyeRepository
{
    private const string UpsertDyeSql = """
        INSERT OR REPLACE INTO dyes
            (id, name, base_r, base_g, base_b, item_id,
             cloth_brightness, cloth_contrast, cloth_hue, cloth_saturation, cloth_lightness, cloth_r, cloth_g, cloth_b,
             leather_brightness, leather_contrast, leather_hue, leather_saturation, leather_lightness, leather_r, leather_g, leather_b,
             metal_brightness, metal_contrast, metal_hue, metal_saturation, metal_lightness, metal_r, metal_g, metal_b,
             fur_brightness, fur_contrast, fur_hue, fur_saturation, fur_lightness, fur_r, fur_g, fur_b)
        VALUES
            (?, ?, ?, ?, ?, ?,
             ?, ?, ?, ?, ?, ?, ?, ?,
             ?, ?, ?, ?, ?, ?, ?, ?,
             ?, ?, ?, ?, ?, ?, ?, ?,
             ?, ?, ?, ?, ?, ?, ?, ?)
        """;

    private const string DeleteDyeCategoriesSql = "DELETE FROM dye_categories WHERE dye_id = ?";

    private const string InsertDyeCategorySql = "INSERT INTO dye_categories (dye_id, category) VALUES (?, ?)";

    private const string SelectDyeSql = """
        SELECT id, name, base_r, base_g, base_b, item_id,
               cloth_brightness, cloth_contrast, cloth_hue, cloth_saturation, cloth_lightness, cloth_r, cloth_g, cloth_b,
               leather_brightness, leather_contrast, leather_hue, leather_saturation, leather_lightness, leather_r, leather_g, leather_b,
               metal_brightness, metal_contrast, metal_hue, metal_saturation, metal_lightness, metal_r, metal_g, metal_b,
               fur_brightness, fur_contrast, fur_hue, fur_saturation, fur_lightness, fur_r, fur_g, fur_b
        FROM dyes
        WHERE id = ?
        """;

    private const string SelectDyeCategoriesSql = "SELECT category FROM dye_categories WHERE dye_id = ? ORDER BY id";

    // Order here must match UpsertDyeSql's column list above, one-for-one — this is the one place that
    // ordering is decided, instead of it being buried inline in Upsert.
    private static object?[] ToUpsertArgs(DyeEntity e) =>
    [
        e.Id, e.Name, e.BaseR, e.BaseG, e.BaseB, e.ItemId,
        e.ClothBrightness, e.ClothContrast, e.ClothHue, e.ClothSaturation, e.ClothLightness, e.ClothR, e.ClothG, e.ClothB,
        e.LeatherBrightness, e.LeatherContrast, e.LeatherHue, e.LeatherSaturation, e.LeatherLightness, e.LeatherR, e.LeatherG, e.LeatherB,
        e.MetalBrightness, e.MetalContrast, e.MetalHue, e.MetalSaturation, e.MetalLightness, e.MetalR, e.MetalG, e.MetalB,
        e.FurBrightness, e.FurContrast, e.FurHue, e.FurSaturation, e.FurLightness, e.FurR, e.FurG, e.FurB,
    ];

    public static void Upsert(SQLiteConnection connection, Dye dye)
    {
        connection.RunInTransaction(() =>
        {
            DyeEntity e = DyeMapper.ToEntity(dye);
            connection.Execute(UpsertDyeSql, ToUpsertArgs(e));
            connection.Execute(DeleteDyeCategoriesSql, dye.Id);
            foreach (DyeCategoryEntity category in DyeMapper.ToCategoryEntities(dye))
            {
                connection.Execute(InsertDyeCategorySql, category.DyeId, category.Category);
            }
        });
    }

    public static Dye? Get(SQLiteConnection connection, int id)
    {
        DyeEntity? entity = connection.Query<DyeEntity>(SelectDyeSql, id).FirstOrDefault();
        if (entity is null) return null;

        var categories = connection.Query<DyeCategoryEntity>(SelectDyeCategoriesSql, id).Select(c => c.Category);
        return DyeMapper.ToModel(entity, categories);
    }
}
