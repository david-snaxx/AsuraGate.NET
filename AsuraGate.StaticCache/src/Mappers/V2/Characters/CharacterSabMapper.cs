using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.StaticCache.Entities.V2.Characters;

namespace AsuraGate.StaticCache.Mappers.V2.Characters;

public static class CharacterSabMapper
{
    public static IEnumerable<CharacterSabZoneEntity> ToZoneEntities(string characterName, CharacterSab sab) =>
        sab.Zones.Select(zone => new CharacterSabZoneEntity()
        {
            CharacterName = characterName,
            ZoneCompletionId = zone.Id,
            Mode = zone.Mode,
            World = zone.World,
            Zone = zone.Zone
        });

    public static IEnumerable<CharacterSabUnlockEntity> ToUnlockEntities(string characterName, CharacterSab sab) =>
        sab.Unlocks.Select(unlock => new CharacterSabUnlockEntity() { CharacterName = characterName, UnlockId = unlock.Id, Name = unlock.Name });

    public static IEnumerable<CharacterSabSongEntity> ToSongEntities(string characterName, CharacterSab sab) =>
        sab.Songs.Select(song => new CharacterSabSongEntity() { CharacterName = characterName, SongId = song.Id, Name = song.Name });

    public static CharacterSab ToModel(
        IEnumerable<CharacterSabZoneEntity> zoneEntities,
        IEnumerable<CharacterSabUnlockEntity> unlockEntities,
        IEnumerable<CharacterSabSongEntity> songEntities) => new CharacterSab()
    {
        Zones = zoneEntities.Select(zone => new SabZone() { Id = zone.ZoneCompletionId, Mode = zone.Mode, World = zone.World, Zone = zone.Zone }).ToArray(),
        Unlocks = unlockEntities.Select(unlock => new SabUnlock() { Id = unlock.UnlockId, Name = unlock.Name }).ToArray(),
        Songs = songEntities.Select(song => new SabSong() { Id = song.SongId, Name = song.Name }).ToArray()
    };
}
