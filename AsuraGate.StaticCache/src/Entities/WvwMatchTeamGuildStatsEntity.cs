using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatchTeamGuildStats"/>. The API scopes this by
/// match/side/sort query parameters not reflected on the model, so a repository should scope and refresh a
/// leaderboard's rows wholesale rather than diff them individually.
/// </summary>
[Table("wvw_match_team_guild_stats")]
public class WvwMatchTeamGuildStatsEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull, Indexed, Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull, Column("kills_red")] public int KillsRed { get; set; }
    [NotNull, Column("kills_blue")] public int KillsBlue { get; set; }
    [NotNull, Column("kills_green")] public int KillsGreen { get; set; }

    [NotNull, Column("deaths_red")] public int DeathsRed { get; set; }
    [NotNull, Column("deaths_blue")] public int DeathsBlue { get; set; }
    [NotNull, Column("deaths_green")] public int DeathsGreen { get; set; }

    [Column("wilson")]
    public double? Wilson { get; set; }
}
