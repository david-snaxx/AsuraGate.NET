using SQLite;

namespace AsuraGate.StaticCache.ETC.Entities;

public class TraitEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("specialization_id")]
    public int SpecializationId { get; set; }
    
    [Column("tier")]
    public int Tier { get; set; }
    
    [Column("order")]
    public int Order { get; set; }
    
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;
    
    
}