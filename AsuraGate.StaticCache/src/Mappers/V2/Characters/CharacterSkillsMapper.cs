using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.StaticCache.Entities.V2.Characters;

namespace AsuraGate.StaticCache.Mappers.V2.Characters;

public static class CharacterSkillsMapper
{
    private static CharacterSkillLoadoutEntity ToLoadoutEntity(string characterName, string mode, SkillLoadout loadout) => new CharacterSkillLoadoutEntity()
    {
        CharacterName = characterName,
        Mode = mode,
        Heal = loadout.Heal,
        HasUtilities = loadout.Utilities is not null,
        Elite = loadout.Elite,
        HasLegends = loadout.Legends is not null
    };

    public static IEnumerable<CharacterSkillLoadoutEntity> ToLoadoutEntities(string characterName, CharacterSkills skills) =>
    [
        ToLoadoutEntity(characterName, "pve", skills.Skills.Pve),
        ToLoadoutEntity(characterName, "pvp", skills.Skills.Pvp),
        ToLoadoutEntity(characterName, "wvw", skills.Skills.Wvw)
    ];

    public static IEnumerable<CharacterSkillUtilityEntity> ToUtilityEntities(string characterName, CharacterSkills skills)
    {
        IEnumerable<CharacterSkillUtilityEntity> ForMode(string mode, SkillLoadout loadout) =>
            (loadout.Utilities ?? []).Select((skillId, index) => new CharacterSkillUtilityEntity() { CharacterName = characterName, Mode = mode, OrderIndex = index, SkillId = skillId });

        return ForMode("pve", skills.Skills.Pve).Concat(ForMode("pvp", skills.Skills.Pvp)).Concat(ForMode("wvw", skills.Skills.Wvw));
    }

    public static IEnumerable<CharacterSkillLegendEntity> ToLegendEntities(string characterName, CharacterSkills skills)
    {
        IEnumerable<CharacterSkillLegendEntity> ForMode(string mode, SkillLoadout loadout) =>
            (loadout.Legends ?? []).Select((legendId, index) => new CharacterSkillLegendEntity() { CharacterName = characterName, Mode = mode, OrderIndex = index, LegendId = legendId });

        return ForMode("pve", skills.Skills.Pve).Concat(ForMode("pvp", skills.Skills.Pvp)).Concat(ForMode("wvw", skills.Skills.Wvw));
    }

    public static CharacterSkills ToModel(
        IEnumerable<CharacterSkillLoadoutEntity> loadoutEntities,
        IEnumerable<CharacterSkillUtilityEntity> utilityEntities,
        IEnumerable<CharacterSkillLegendEntity> legendEntities)
    {
        var loadouts = loadoutEntities.ToList();
        var utilities = utilityEntities.ToList();
        var legends = legendEntities.ToList();

        SkillLoadout ForMode(string mode)
        {
            var loadout = loadouts.First(l => l.Mode == mode);
            return new SkillLoadout()
            {
                Heal = loadout.Heal,
                Utilities = loadout.HasUtilities ? utilities.Where(u => u.Mode == mode).OrderBy(u => u.OrderIndex).Select(u => u.SkillId).ToArray() : null,
                Elite = loadout.Elite,
                Legends = loadout.HasLegends ? legends.Where(l => l.Mode == mode).OrderBy(l => l.OrderIndex).Select(l => l.LegendId).ToArray() : null
            };
        }

        return new CharacterSkills()
        {
            Skills = new SkillsByMode() { Pve = ForMode("pve"), Pvp = ForMode("pvp"), Wvw = ForMode("wvw") }
        };
    }
}
