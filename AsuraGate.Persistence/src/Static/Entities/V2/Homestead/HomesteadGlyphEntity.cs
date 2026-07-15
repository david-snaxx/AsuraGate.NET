using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2.Homestead;

[Table("homestead_glyphs")]
public class HomesteadGlyphEntity : IIdDataEntity<string>
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
