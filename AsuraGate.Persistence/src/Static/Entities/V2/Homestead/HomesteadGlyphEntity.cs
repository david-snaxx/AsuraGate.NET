using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Homestead;

[Table("homestead_glyphs")]
public class HomesteadGlyphEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
