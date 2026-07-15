using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2.Mount;

[Table("mount_skins")]
public class MountSkinEntity : IIdDataEntity<int>
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
