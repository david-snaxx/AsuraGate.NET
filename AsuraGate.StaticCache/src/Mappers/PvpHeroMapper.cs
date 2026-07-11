using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="PvpHero"/> to <see cref="PvpHeroEntity"/>.
/// </summary>
public static class PvpHeroMapper
{
    public static PvpHeroEntity ToEntity(PvpHero hero) => new PvpHeroEntity()
    {
        Id = hero.Id,
        Name = hero.Name,
        Description = hero.Description,
        Type = hero.Type,
        StatsOffense = hero.Stats.Offense,
        StatsDefense = hero.Stats.Defense,
        StatsSpeed = hero.Stats.Speed,
        Overlay = hero.Overlay,
        Underlay = hero.Underlay,
    };

    public static IReadOnlyList<PvpHeroSkinEntity> ToSkinEntities(PvpHero hero) =>
        hero.Skins.Select(skin => new PvpHeroSkinEntity()
        {
            Id = skin.Id,
            HeroId = hero.Id,
            Name = skin.Name,
            Icon = skin.Icon,
            IsDefault = skin.IsDefault,
        }).ToList();

    public static IReadOnlyList<PvpHeroSkinUnlockItemEntity> ToSkinUnlockItemEntities(PvpHeroSkin skin) =>
        skin.UnlockItems.Select(itemId => new PvpHeroSkinUnlockItemEntity() { PvpHeroSkinId = skin.Id, ItemId = itemId }).ToList();

    public static PvpHeroSkin ToSkinModel(PvpHeroSkinEntity entity, IEnumerable<int> unlockItems) => new PvpHeroSkin()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        IsDefault = entity.IsDefault,
        UnlockItems = unlockItems.ToArray(),
    };

    public static PvpHero ToModel(PvpHeroEntity entity, IEnumerable<PvpHeroSkin> skins) => new PvpHero()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Type = entity.Type,
        Stats = new PvpHeroStats() { Offense = entity.StatsOffense, Defense = entity.StatsDefense, Speed = entity.StatsSpeed },
        Overlay = entity.Overlay,
        Underlay = entity.Underlay,
        Skins = skins.ToArray(),
    };
}
