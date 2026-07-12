using SQLite;

namespace AsuraGate.Spec.Entities.V2.Wvw;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwTimer"/>. The model has no ID at all and
/// there's only ever one (the current reset schedule), so this row uses a fixed constant primary key.
/// </summary>
[Table("wvw_timers")]
public class WvwTimerEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; } = 1;

    [NotNull]
    [Column("na")]
    public DateTime Na { get; set; }

    [NotNull]
    [Column("eu")]
    public DateTime Eu { get; set; }
}
