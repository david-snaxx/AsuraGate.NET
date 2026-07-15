using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class StoryJournalEntryMapper
{
    public static StoryJournalEntryEntity ToEntity(StoryJournalEntry model) => new StoryJournalEntryEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static StoryJournalEntry ToModel(StoryJournalEntryEntity entity) => JsonSerializer.Deserialize<StoryJournalEntry>(entity.Data)!;
}
