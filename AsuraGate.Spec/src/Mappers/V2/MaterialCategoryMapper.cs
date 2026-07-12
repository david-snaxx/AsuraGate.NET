using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class MaterialCategoryMapper
{
    public static MaterialCategoryEntity ToMaterialCategoryEntity(MaterialCategory materialCategory) => new MaterialCategoryEntity()
    {
        Id = materialCategory.Id,
        Name = materialCategory.Name,
        Order = materialCategory.Order
    };

    public static IEnumerable<MaterialCategoryItemEntity> ToItemEntities(MaterialCategory materialCategory) =>
        materialCategory.Items.Select(itemId => new MaterialCategoryItemEntity()
        {
            MaterialCategoryId = materialCategory.Id,
            ItemId = itemId
        });

    public static MaterialCategory ToModel(MaterialCategoryEntity entity, IEnumerable<MaterialCategoryItemEntity> itemEntities) => new MaterialCategory()
    {
        Id = entity.Id,
        Name = entity.Name,
        Order = entity.Order,
        Items = itemEntities.Select(item => item.ItemId).ToArray()
    };
}
