using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class ApiFileMapper
{
    public static ApiFileEntity ToEntity(ApiFile model) => new ApiFileEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static ApiFile ToModel(ApiFileEntity entity) => JsonSerializer.Deserialize<ApiFile>(entity.Data)!;
}
