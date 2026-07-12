using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class RaidMapper
{
    public static RaidEntity ToRaidEntity(Raid raid) => new RaidEntity()
    {
        Id = raid.Id
    };

    public static IEnumerable<RaidWingEntity> ToWingEntities(Raid raid) =>
        raid.Wings.Select((wing, index) => new RaidWingEntity()
        {
            RaidId = raid.Id,
            OrderIndex = index,
            WingId = wing.Id
        });

    public static IEnumerable<RaidEventEntity> ToEventEntities(Raid raid) =>
        raid.Wings.SelectMany(wing => wing.Events.Select((@event, index) => new RaidEventEntity()
        {
            RaidId = raid.Id,
            WingId = wing.Id,
            OrderIndex = index,
            EventId = @event.Id,
            Type = @event.Type
        }));

    public static Raid ToModel(
        RaidEntity entity,
        IEnumerable<RaidWingEntity> wingEntities,
        IEnumerable<RaidEventEntity> eventEntities) => new Raid()
    {
        Id = entity.Id,
        Wings = wingEntities.OrderBy(wing => wing.OrderIndex).Select(wing => new RaidWing()
        {
            Id = wing.WingId,
            Events = eventEntities
                .Where(@event => @event.WingId == wing.WingId)
                .OrderBy(@event => @event.OrderIndex)
                .Select(@event => new RaidEvent() { Id = @event.EventId, Type = @event.Type })
                .ToArray()
        }).ToArray()
    };
}
