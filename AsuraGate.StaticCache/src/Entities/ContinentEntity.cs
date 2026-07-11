using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Continent"/>.
/// </summary>
[Table("continents")]
public class ContinentEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
    
    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [Column("dim_width")]
    public int ContinentDimWidth { get; set; }
    
    [Column("dim_height")]
    public int ContinentDimHeight { get; set; }
    
    [NotNull, Column("min_zoom")]
    public int MinZoom { get; set; }
    
    [NotNull, Column("max_zoom")]
    public int MaxZoom { get; set; }
}