using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwTimer"/>. The model has no id (it's a single
/// pair of reset timestamps), so this holds one row keyed on a fixed id of 1.
/// </summary>
[Table("wvw_timer")]
public class WvwTimerEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; } = 1;

    [NotNull, Column("na")]
    public DateTime Na { get; set; }

    [NotNull, Column("eu")]
    public DateTime Eu { get; set; }
}
