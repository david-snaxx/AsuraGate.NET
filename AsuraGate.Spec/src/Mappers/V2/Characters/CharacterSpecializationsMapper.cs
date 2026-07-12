using AsuraGate.Spec.Entities.V2.Characters;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Spec.Mappers.V2.Characters;

public static class CharacterSpecializationsMapper
{
    public static IEnumerable<CharacterSpecializationSlotEntity> ToSlotEntities(string characterName, CharacterSpecializations specializations)
    {
        IEnumerable<CharacterSpecializationSlotEntity> ForMode(string mode, SpecializationSlot[] slots) =>
            slots.Select((slot, index) => new CharacterSpecializationSlotEntity()
            {
                CharacterName = characterName,
                Mode = mode,
                OrderIndex = index,
                SpecializationId = slot.Id,
                HasTraits = slot.Traits is not null
            });

        return ForMode("pve", specializations.Specializations.Pve)
            .Concat(ForMode("pvp", specializations.Specializations.Pvp))
            .Concat(ForMode("wvw", specializations.Specializations.Wvw));
    }

    public static IEnumerable<CharacterSpecializationSlotTraitEntity> ToTraitEntities(string characterName, CharacterSpecializations specializations)
    {
        IEnumerable<CharacterSpecializationSlotTraitEntity> ForMode(string mode, SpecializationSlot[] slots) =>
            slots.SelectMany((slot, slotIndex) => (slot.Traits ?? []).Select((traitId, index) => new CharacterSpecializationSlotTraitEntity()
            {
                CharacterName = characterName,
                Mode = mode,
                SlotOrderIndex = slotIndex,
                OrderIndex = index,
                TraitId = traitId
            }));

        return ForMode("pve", specializations.Specializations.Pve)
            .Concat(ForMode("pvp", specializations.Specializations.Pvp))
            .Concat(ForMode("wvw", specializations.Specializations.Wvw));
    }

    public static CharacterSpecializations ToModel(
        IEnumerable<CharacterSpecializationSlotEntity> slotEntities,
        IEnumerable<CharacterSpecializationSlotTraitEntity> traitEntities)
    {
        var slots = slotEntities.ToList();
        var traits = traitEntities.ToList();

        SpecializationSlot[] ForMode(string mode) => slots
            .Where(slot => slot.Mode == mode)
            .OrderBy(slot => slot.OrderIndex)
            .Select(slot => new SpecializationSlot()
            {
                Id = slot.SpecializationId,
                Traits = slot.HasTraits
                    ? traits.Where(trait => trait.Mode == mode && trait.SlotOrderIndex == slot.OrderIndex).OrderBy(trait => trait.OrderIndex).Select(trait => trait.TraitId).ToArray()
                    : null
            }).ToArray();

        return new CharacterSpecializations()
        {
            Specializations = new SpecializationsByMode() { Pve = ForMode("pve"), Pvp = ForMode("pvp"), Wvw = ForMode("wvw") }
        };
    }
}
