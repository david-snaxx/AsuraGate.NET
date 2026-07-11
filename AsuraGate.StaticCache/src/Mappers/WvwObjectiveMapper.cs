using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwObjective"/> to <see cref="WvwObjectiveEntity"/>.
/// </summary>
public static class WvwObjectiveMapper
{
    public static WvwObjectiveEntity ToEntity(WvwObjective objective) => new WvwObjectiveEntity()
    {
        Id = objective.Id,
        Name = objective.Name,
        Type = objective.Type,
        SectorId = objective.SectorId,
        MapId = objective.MapId,
        MapType = objective.MapType,
        CoordX = objective.Coord.ElementAtOrDefault(0),
        CoordY = objective.Coord.ElementAtOrDefault(1),
        CoordZ = objective.Coord.ElementAtOrDefault(2),
        LabelCoordX = objective.LabelCoord.ElementAtOrDefault(0),
        LabelCoordY = objective.LabelCoord.ElementAtOrDefault(1),
        Marker = objective.Marker,
        ChatLink = objective.ChatLink,
        UpgradeId = objective.UpgradeId,
    };

    public static WvwObjective ToModel(WvwObjectiveEntity entity) => new WvwObjective()
    {
        Id = entity.Id,
        Name = entity.Name,
        Type = entity.Type,
        SectorId = entity.SectorId,
        MapId = entity.MapId,
        MapType = entity.MapType,
        Coord = [entity.CoordX, entity.CoordY, entity.CoordZ],
        LabelCoord = [entity.LabelCoordX, entity.LabelCoordY],
        Marker = entity.Marker,
        ChatLink = entity.ChatLink,
        UpgradeId = entity.UpgradeId,
    };
}
