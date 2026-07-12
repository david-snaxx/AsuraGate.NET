using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

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
