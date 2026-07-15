using SQLite;

namespace AsuraGate.Persistence.Static.Meta;

[Table("static_meta")]
public class StaticMetaEntity
{
    // id = cache table name
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;
    
    [Column("has_fetched_all")]
    public bool HasFetchedAll { get; set; }
    
    [Column("fetched_all_at")]
    public DateTime FetchedAllAt { get; set; }
    
    [Column("fetched_all_build_id")]
    public int FetchedAllBuildId { get; set; }
}