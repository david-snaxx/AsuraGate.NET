using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Raid"/>.
/// </summary>
[Table("raids")]
public class RaidEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;
}

/// <summary>Wing within a <see cref="RaidEntity"/>.</summary>
[Table("raid_wings")]
public class RaidWingEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("raid_id")]
    public string RaidId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("wing_id")]
    public string WingId { get; set; } = string.Empty;
}

/// <summary>
/// Event (boss encounter or checkpoint) within a <see cref="RaidWingEntity"/>. Carries the raid ID down
/// directly (rather than a FK to the wing's generated surrogate key) so this row can be built straight
/// from the source model without needing the wing's row to be inserted first.
/// </summary>
[Table("raid_events")]
public class RaidEventEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("raid_id")]
    public string RaidId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("wing_id")]
    public string WingId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("event_id")]
    public string EventId { get; set; } = string.Empty;

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;
}
