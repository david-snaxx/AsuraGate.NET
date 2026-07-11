using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.MailCarrier"/>.
/// </summary>
[Table("mail_carriers")]
public class MailCarrierEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Indexed, Column("order")]
    public int Order { get; set; }
}

/// <summary>Items that unlock a <see cref="MailCarrierEntity"/>.</summary>
[Table("mail_carrier_unlock_items")]
public class MailCarrierUnlockItemEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("mail_carrier_id")]
    public int MailCarrierId { get; set; } // FK to MailCarrierEntity

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity
}

/// <summary>Behavior flags on a <see cref="MailCarrierEntity"/> (e.g. "Default").</summary>
[Table("mail_carrier_flags")]
public class MailCarrierFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("mail_carrier_id")]
    public int MailCarrierId { get; set; } // FK to MailCarrierEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}
