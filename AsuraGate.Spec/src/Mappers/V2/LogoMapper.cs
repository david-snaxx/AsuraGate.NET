using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class LogoMapper
{
    public static LogoEntity ToLogoEntity(Logo logo) => new LogoEntity()
    {
        Id = logo.Id,
        Url = logo.Url
    };

    public static Logo ToModel(LogoEntity entity) => new Logo()
    {
        Id = entity.Id,
        Url = entity.Url
    };
}
