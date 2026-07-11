using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpGame"/>.
/// </summary>
[Table("pvp_games")]
public class PvpGameEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("map_id")]
    public int MapId { get; set; }

    [NotNull, Indexed, Column("started")]
    public DateTime Started { get; set; }

    [NotNull, Column("ended")]
    public DateTime Ended { get; set; }

    [NotNull, Indexed, Column("result")]
    public string Result { get; set; } = string.Empty;

    [NotNull, Column("team")]
    public string Team { get; set; } = string.Empty;

    [NotNull, Indexed, Column("profession")]
    public string Profession { get; set; } = string.Empty;

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }

    [NotNull, Column("rating_type")]
    public string RatingType { get; set; } = string.Empty;

    [Column("rating_change")]
    public int? RatingChange { get; set; }

    [Indexed, Column("season_id")]
    public string? SeasonId { get; set; } // FK to PvpSeasonEntity
}
