using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class ApiFileMapper
{
    public static ApiFileEntity ToApiFileEntity(ApiFile apiFile) => new ApiFileEntity()
    {
        Id = apiFile.Id,
        Icon = apiFile.Icon
    };

    public static ApiFile ToModel(ApiFileEntity entity) => new ApiFile()
    {
        Id = entity.Id,
        Icon = entity.Icon
    };
}
