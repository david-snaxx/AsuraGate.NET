using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Characters;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Characters.CharacterCore"/>. Character names are
/// globally unique in GW2, so <see cref="Name"/> serves as the primary key directly - unlike every other
/// Character/* model (which are sub-resources fetched by character name and don't carry it themselves),
/// this one doesn't need an externally-supplied key.
/// </summary>
[Table("character_cores")]
public class CharacterCoreEntity
{
    [PrimaryKey]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("race")]
    public string Race { get; set; } = string.Empty;

    [NotNull]
    [Column("gender")]
    public string Gender { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("profession")]
    public string Profession { get; set; } = string.Empty;

    [NotNull]
    [Column("level")]
    public int Level { get; set; }

    [Indexed]
    [Column("guild")]
    public string? Guild { get; set; }

    [NotNull]
    [Column("age")]
    public int Age { get; set; }

    [NotNull]
    [Column("created")]
    public DateTime Created { get; set; }

    [NotNull]
    [Column("last_modified")]
    public DateTime LastModified { get; set; }

    [NotNull]
    [Column("deaths")]
    public int Deaths { get; set; }

    [Column("title")]
    public int? Title { get; set; }
}
