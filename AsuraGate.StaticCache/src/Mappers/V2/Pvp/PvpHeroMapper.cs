using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities.V2.Pvp;

namespace AsuraGate.StaticCache.Mappers.V2.Pvp;

public static class PvpHeroMapper
{
    public static PvpHeroEntity ToPvpHeroEntity(PvpHero hero) => new PvpHeroEntity()
    {
        Id = hero.Id,
        Name = hero.Name,
        Description = hero.Description,
        Type = hero.Type,
        StatsOffense = hero.Stats.Offense,
        StatsDefense = hero.Stats.Defense,
        StatsSpeed = hero.Stats.Speed,
        Overlay = hero.Overlay,
        Underlay = hero.Underlay
    };

    public static IEnumerable<PvpHeroSkinEntity> ToSkinEntities(PvpHero hero) =>
        hero.Skins.Select(skin => new PvpHeroSkinEntity()
        {
            Id = skin.Id,
            PvpHeroId = hero.Id,
            Name = skin.Name,
            Icon = skin.Icon,
            IsDefault = skin.IsDefault
        });

    public static IEnumerable<PvpHeroSkinUnlockItemEntity> ToUnlockItemEntities(PvpHero hero) =>
        hero.Skins.SelectMany(skin => skin.UnlockItems.Select(itemId => new PvpHeroSkinUnlockItemEntity() { PvpHeroSkinId = skin.Id, ItemId = itemId }));

    public static PvpHero ToModel(
        PvpHeroEntity entity,
        IEnumerable<PvpHeroSkinEntity> skinEntities,
        IEnumerable<PvpHeroSkinUnlockItemEntity> unlockItemEntities)
    {
        var unlockItems = unlockItemEntities.ToList();

        return new PvpHero()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Type = entity.Type,
            Stats = new PvpHeroStats() { Offense = entity.StatsOffense, Defense = entity.StatsDefense, Speed = entity.StatsSpeed },
            Overlay = entity.Overlay,
            Underlay = entity.Underlay,
            Skins = skinEntities.Select(skin => new PvpHeroSkin()
            {
                Id = skin.Id,
                Name = skin.Name,
                Icon = skin.Icon,
                IsDefault = skin.IsDefault,
                UnlockItems = unlockItems.Where(item => item.PvpHeroSkinId == skin.Id).Select(item => item.ItemId).ToArray()
            }).ToArray()
        };
    }
}
