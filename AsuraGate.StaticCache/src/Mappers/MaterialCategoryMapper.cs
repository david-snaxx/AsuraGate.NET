using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="MaterialCategory"/> to <see cref="MaterialCategoryEntity"/>.
/// </summary>
public static class MaterialCategoryMapper
{
    public static MaterialCategoryEntity ToEntity(MaterialCategory category) => new MaterialCategoryEntity()
    {
        Id = category.Id,
        Name = category.Name,
        Order = category.Order,
    };

    public static IReadOnlyList<MaterialCategoryItemEntity> ToItemEntities(MaterialCategory category) =>
        category.Items.Select(itemId => new MaterialCategoryItemEntity() { MaterialCategoryId = category.Id, ItemId = itemId }).ToList();

    public static MaterialCategory ToModel(MaterialCategoryEntity entity, IEnumerable<int> items) => new MaterialCategory()
    {
        Id = entity.Id,
        Name = entity.Name,
        Order = entity.Order,
        Items = items.ToArray(),
    };
}
