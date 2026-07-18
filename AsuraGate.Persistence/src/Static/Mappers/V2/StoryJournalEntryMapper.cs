using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class StoryJournalEntryMapper
{
    public static StoryJournalEntryEntity ToEntity(StoryJournalEntry model) => new StoryJournalEntryEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static StoryJournalEntry? ToModel(StoryJournalEntryEntity entity) => MapperUtils.DeserializeJson<StoryJournalEntry>(entity.Data);
}
