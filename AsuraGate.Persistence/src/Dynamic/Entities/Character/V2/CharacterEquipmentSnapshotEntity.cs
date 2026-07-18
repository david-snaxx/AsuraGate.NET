using SQLite;

namespace AsuraGate.Persistence.Dynamic.Entities.Character.V2;

[Table("character_equipment_snapshots")]
public class CharacterEquipmentSnapshotEntity : IKeyedSnapshotEntity
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("character_name")]
    public string Key { get; set; } = string.Empty;

    [NotNull]
    [Column("timestamp")]
    public DateTime Timestamp { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
