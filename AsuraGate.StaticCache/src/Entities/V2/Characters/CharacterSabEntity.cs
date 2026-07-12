using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Characters;

/// <summary>A completed SAB zone for a character. Callers must supply <see cref="CharacterName"/>.</summary>
[Table("character_sab_zones")]
public class CharacterSabZoneEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("zone_completion_id")]
    public int ZoneCompletionId { get; set; }

    [NotNull]
    [Column("mode")]
    public string Mode { get; set; } = string.Empty;

    [NotNull]
    [Column("world")]
    public int World { get; set; }

    [NotNull]
    [Column("zone")]
    public int Zone { get; set; }
}

/// <summary>A purchased SAB upgrade for a character. Callers must supply <see cref="CharacterName"/>.</summary>
[Table("character_sab_unlocks")]
public class CharacterSabUnlockEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("unlock_id")]
    public int UnlockId { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}

/// <summary>A SAB flute song unlocked by a character. Callers must supply <see cref="CharacterName"/>.</summary>
[Table("character_sab_songs")]
public class CharacterSabSongEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("song_id")]
    public int SongId { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}
