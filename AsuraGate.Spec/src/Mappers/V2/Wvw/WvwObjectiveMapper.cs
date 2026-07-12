using AsuraGate.Spec.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Spec.Mappers.V2.Wvw;

public static class WvwObjectiveMapper
{
    public static WvwObjectiveEntity ToWvwObjectiveEntity(WvwObjective objective) => new WvwObjectiveEntity()
    {
        Id = objective.Id,
        Name = objective.Name,
        Type = objective.Type,
        SectorId = objective.SectorId,
        MapId = objective.MapId,
        MapType = objective.MapType,
        CoordX = objective.Coord[0],
        CoordY = objective.Coord[1],
        CoordZ = objective.Coord[2],
        LabelCoordX = objective.LabelCoord[0],
        LabelCoordY = objective.LabelCoord[1],
        Marker = objective.Marker,
        ChatLink = objective.ChatLink,
        UpgradeId = objective.UpgradeId
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
        UpgradeId = entity.UpgradeId
    };
}
