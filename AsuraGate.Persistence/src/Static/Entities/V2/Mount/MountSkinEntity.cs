using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Mount;

[Table("mount_skins")]
public class MountSkinEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
