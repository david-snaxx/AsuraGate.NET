using SQLite;

namespace AsuraGate.Spec.Entities.V2.Pvp;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpGame"/>. <c>Scores</c> is a fixed 1:1
/// object, flattened onto this row. The model's own <c>Id</c> (a real match UUID) is globally unique,
/// so unlike the Guild/* models this doesn't need an externally-supplied owner key.
/// </summary>
[Table("pvp_games")]
public class PvpGameEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull]
    [Column("started")]
    public DateTime Started { get; set; }

    [NotNull]
    [Column("ended")]
    public DateTime Ended { get; set; }

    [NotNull]
    [Column("result")]
    public string Result { get; set; } = string.Empty;

    [NotNull]
    [Column("team")]
    public string Team { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("profession")]
    public string Profession { get; set; } = string.Empty;

    [NotNull]
    [Column("score_red")]
    public int ScoreRed { get; set; }

    [NotNull]
    [Column("score_blue")]
    public int ScoreBlue { get; set; }

    [NotNull]
    [Column("rating_type")]
    public string RatingType { get; set; } = string.Empty;

    [Column("rating_change")]
    public int? RatingChange { get; set; }

    [Indexed]
    [Column("season")]
    public string? Season { get; set; }
}
