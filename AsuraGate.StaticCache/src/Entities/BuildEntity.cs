using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Build"/>. Single-row table: only the most recently
/// fetched build is kept, used to detect when cached static data is stale.
/// </summary>
[Table("build")]
public class BuildEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
}
