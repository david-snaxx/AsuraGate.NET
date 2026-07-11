using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Raid"/> to <see cref="RaidEntity"/>. <see cref="RaidWingEntity"/> uses a DB-assigned id
/// (not provided by the API), so <see cref="ToEventEntities"/> takes the already-persisted wing id.
/// </summary>
public static class RaidMapper
{
    public static RaidEntity ToEntity(Raid raid) => new RaidEntity()
    {
        Id = raid.Id,
    };

    public static RaidWingEntity ToWingEntity(RaidWing wing, string raidId) => new RaidWingEntity()
    {
        RaidId = raidId,
        WingId = wing.Id,
    };

    public static IReadOnlyList<RaidEventEntity> ToEventEntities(RaidWing wing, int raidWingId) =>
        wing.Events.Select(evt => new RaidEventEntity()
        {
            RaidWingId = raidWingId,
            EventId = evt.Id,
            Type = evt.Type,
        }).ToList();

    public static RaidEvent ToEventModel(RaidEventEntity entity) => new RaidEvent()
    {
        Id = entity.EventId,
        Type = entity.Type,
    };

    public static RaidWing ToWingModel(RaidWingEntity entity, IEnumerable<RaidEvent> events) => new RaidWing()
    {
        Id = entity.WingId,
        Events = events.ToArray(),
    };

    public static Raid ToModel(RaidEntity entity, IEnumerable<RaidWing> wings) => new Raid()
    {
        Id = entity.Id,
        Wings = wings.ToArray(),
    };
}
