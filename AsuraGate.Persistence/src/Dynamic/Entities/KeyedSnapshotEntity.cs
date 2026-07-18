using SQLite;

namespace AsuraGate.Persistence.Dynamic.Entities;

/// <summary>
/// Base for keyed snapshot entities - adds the character name key column on top of
/// <see cref="SnapshotEntity"/>'s id/timestamp/data. Concrete entities just add <c>[Table("...")]</c>.
/// </summary>
public abstract class KeyedSnapshotEntity : SnapshotEntity, IKeyedSnapshotEntity
{
    [Indexed]
    [NotNull]
    [Column("character_name")]
    public string Key { get; set; } = string.Empty;
}
