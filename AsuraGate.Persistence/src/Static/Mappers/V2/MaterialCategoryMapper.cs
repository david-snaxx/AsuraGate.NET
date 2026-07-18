using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class MaterialCategoryMapper
{
    public static MaterialCategoryEntity ToEntity(MaterialCategory model) => new MaterialCategoryEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static MaterialCategory? ToModel(MaterialCategoryEntity entity) => MapperUtils.DeserializeJson<MaterialCategory>(entity.Data);
}
