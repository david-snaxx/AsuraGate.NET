using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Wvw;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Wvw.WvwMatchTeamGuildStats"/>. Result of a
/// per-match, per-side leaderboard query - the model has no match/side context of its own, so callers
/// must supply <see cref="MatchId"/> and <see cref="Side"/>.
/// </summary>
[Table("wvw_match_team_guild_stats")]
public class WvwMatchTeamGuildStatsEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("match_id")]
    public string MatchId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("side")]
    public string Side { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("kills_red")]
    public int KillsRed { get; set; }

    [NotNull]
    [Column("kills_blue")]
    public int KillsBlue { get; set; }

    [NotNull]
    [Column("kills_green")]
    public int KillsGreen { get; set; }

    [NotNull]
    [Column("deaths_red")]
    public int DeathsRed { get; set; }

    [NotNull]
    [Column("deaths_blue")]
    public int DeathsBlue { get; set; }

    [NotNull]
    [Column("deaths_green")]
    public int DeathsGreen { get; set; }

    [Column("wilson")]
    public double? Wilson { get; set; }
}
