using SQLite;

namespace AsuraGate.StaticCache.ETC.Entities;

[Table("worlds")]
public class WorldEntity
{
    [PrimaryKey] 
    [Column("id")] 
    public int Id { get; set; }

    [NotNull] 
    [Indexed] 
    [Column("name")] 
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("population")]
    public string Population { get; set; } = string.Empty;
}