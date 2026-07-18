namespace AsuraGate.Persistence.Dynamic.Entities;

/// <summary>
/// Extends <see cref="ISnapshotEntity"/> with a subject key column, for snapshot tables where a
/// single database holds interleaved history for more than one subject (e.g. every character on
/// an account) and rows need to be filtered down to one subject's timeline. Keyed by string since
/// every current subject (character name) is naturally a string.
/// </summary>
public interface IKeyedSnapshotEntity : ISnapshotEntity
{
    string Key { get; set; }
}
