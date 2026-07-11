using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Raid"/>.
/// </summary>
[Table("raids")]
public class RaidEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;
}

/// <summary>A wing within a <see cref="RaidEntity"/>.</summary>
[Table("raid_wings")]
public class RaidWingEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_raid_wings_raid_id_wing_id", Order = 1, Unique = true)]
    [Column("raid_id")]
    public string RaidId { get; set; } = string.Empty; // FK to RaidEntity

    [NotNull]
    [Indexed(Name = "ux_raid_wings_raid_id_wing_id", Order = 2, Unique = true)]
    [Column("wing_id")]
    public string WingId { get; set; } = string.Empty; // api "id" value
}

/// <summary>A boss encounter or checkpoint within a <see cref="RaidWingEntity"/>.</summary>
[Table("raid_events")]
public class RaidEventEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_raid_events_wing_id_event_id", Order = 1, Unique = true)]
    [Column("raid_wing_id")]
    public int RaidWingId { get; set; } // FK to RaidWingEntity, not provided by API

    [NotNull]
    [Indexed(Name = "ux_raid_events_wing_id_event_id", Order = 2, Unique = true)]
    [Column("event_id")]
    public string EventId { get; set; } = string.Empty; // api "id" value

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;
}
