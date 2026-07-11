using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="ApiFile"/> to <see cref="ApiFileEntity"/>.
/// </summary>
public static class ApiFileMapper
{
    public static ApiFileEntity ToEntity(ApiFile apiFile) => new ApiFileEntity()
    {
        Id = apiFile.Id,
        Icon = apiFile.Icon,
    };

    public static ApiFile ToModel(ApiFileEntity entity) => new ApiFile()
    {
        Id = entity.Id,
        Icon = entity.Icon,
    };
}
