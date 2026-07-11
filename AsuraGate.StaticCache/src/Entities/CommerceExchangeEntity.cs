using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommerceExchange"/>. The model has no id and
/// represents a live, query-parameterized exchange rate (it varies by direction and requested quantity), so
/// this is a best-effort snapshot cache keyed by direction rather than a true catalog table.
/// </summary>
[Table("commerce_exchange")]
public class CommerceExchangeEntity
{
    [PrimaryKey, Column("direction")]
    public string Direction { get; set; } = string.Empty; // "CoinsToGems" or "GemsToCoins"

    [NotNull, Column("coins_per_gem")]
    public int CoinsPerGem { get; set; }

    [NotNull, Column("quantity")]
    public int Quantity { get; set; }
}
