using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Build"/> to <see cref="BuildEntity"/>.
/// </summary>
public static class BuildMapper
{
    public static BuildEntity ToEntity(Build build) => new BuildEntity()
    {
        Id = build.Id,
    };

    public static Build ToModel(BuildEntity entity) => new Build()
    {
        Id = entity.Id,
    };
}
