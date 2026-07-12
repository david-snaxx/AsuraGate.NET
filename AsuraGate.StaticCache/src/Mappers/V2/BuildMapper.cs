using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class BuildMapper
{
    public static BuildEntity ToBuildEntity(Build build) => new BuildEntity()
    {
        Id = build.Id
    };

    public static Build ToModel(BuildEntity entity) => new Build()
    {
        Id = entity.Id
    };
}
