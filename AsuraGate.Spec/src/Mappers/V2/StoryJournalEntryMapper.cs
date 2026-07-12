using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class StoryJournalEntryMapper
{
    public static StoryJournalEntryEntity ToStoryJournalEntryEntity(StoryJournalEntry entry) => new StoryJournalEntryEntity()
    {
        Id = entry.Id,
        Name = entry.Name,
        Level = entry.Level,
        Story = entry.Story
    };

    public static IEnumerable<StoryGoalEntity> ToGoalEntities(StoryJournalEntry entry) =>
        entry.Goals.Select((goal, index) => new StoryGoalEntity()
        {
            StoryJournalEntryId = entry.Id,
            OrderIndex = index,
            Active = goal.Active,
            Complete = goal.Complete
        });

    public static StoryJournalEntry ToModel(StoryJournalEntryEntity entity, IEnumerable<StoryGoalEntity> goalEntities) => new StoryJournalEntry()
    {
        Id = entity.Id,
        Name = entity.Name,
        Level = entity.Level,
        Story = entity.Story,
        Goals = goalEntities.OrderBy(goal => goal.OrderIndex).Select(goal => new StoryGoal()
        {
            Active = goal.Active,
            Complete = goal.Complete
        }).ToArray()
    };
}
