using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Mini"/> to <see cref="MiniEntity"/>.
/// </summary>
public static class MiniMapper
{
    public static MiniEntity ToEntity(Mini mini) => new MiniEntity()
    {
        Id = mini.Id,
        Name = mini.Name,
        Unlock = mini.Unlock,
        Icon = mini.Icon,
        Order = mini.Order,
        ItemId = mini.ItemId,
    };

    public static Mini ToModel(MiniEntity entity) => new Mini()
    {
        Id = entity.Id,
        Name = entity.Name,
        Unlock = entity.Unlock,
        Icon = entity.Icon,
        Order = entity.Order,
        ItemId = entity.ItemId,
    };
}
