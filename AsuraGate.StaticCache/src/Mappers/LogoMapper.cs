using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Logo"/> to <see cref="LogoEntity"/>.
/// </summary>
public static class LogoMapper
{
    public static LogoEntity ToEntity(Logo logo) => new LogoEntity()
    {
        Id = logo.Id,
        Url = logo.Url,
    };

    public static Logo ToModel(LogoEntity entity) => new Logo()
    {
        Id = entity.Id,
        Url = entity.Url,
    };
}
