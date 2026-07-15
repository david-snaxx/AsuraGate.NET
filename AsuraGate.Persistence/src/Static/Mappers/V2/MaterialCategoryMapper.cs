using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class MaterialCategoryMapper
{
    public static MaterialCategoryEntity ToEntity(MaterialCategory model) => new MaterialCategoryEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static MaterialCategory ToModel(MaterialCategoryEntity entity) => JsonSerializer.Deserialize<MaterialCategory>(entity.Data)!;
}
