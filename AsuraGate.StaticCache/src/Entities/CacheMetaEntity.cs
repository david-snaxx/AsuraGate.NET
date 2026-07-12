using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// Tracks, per cached table, the last time a full "insert-all" sync completed - i.e. when that
/// table was last considered fully repopulated from the live API. Not tied to any GW2 API model,
/// so it lives outside the V2 folder structure.
/// </summary>
[Table("cache_meta")]
public class CacheMetaEntity
{
    [PrimaryKey]
    [Column("table_name")]
    public string TableName { get; set; } = string.Empty;

    [NotNull]
    [Column("last_full_sync_at")]
    public DateTime LastFullSyncAt { get; set; }
}
