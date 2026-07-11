using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="StoryJournalEntry"/> to <see cref="StoryJournalEntryEntity"/>.
/// </summary>
public static class StoryJournalEntryMapper
{
    public static StoryJournalEntryEntity ToEntity(StoryJournalEntry entry) => new StoryJournalEntryEntity()
    {
        Id = entry.Id,
        Name = entry.Name,
        Level = entry.Level,
        StoryId = entry.Story,
    };

    public static IReadOnlyList<StoryJournalEntryGoalEntity> ToGoalEntities(StoryJournalEntry entry) =>
        entry.Goals.Select((goal, index) => new StoryJournalEntryGoalEntity()
        {
            StoryJournalEntryId = entry.Id,
            OrderIndex = index,
            Active = goal.Active,
            Complete = goal.Complete,
        }).ToList();

    public static StoryGoal ToGoalModel(StoryJournalEntryGoalEntity entity) => new StoryGoal()
    {
        Active = entity.Active,
        Complete = entity.Complete,
    };

    public static StoryJournalEntry ToModel(StoryJournalEntryEntity entity, IEnumerable<StoryJournalEntryGoalEntity> goals) => new StoryJournalEntry()
    {
        Id = entity.Id,
        Name = entity.Name,
        Level = entity.Level,
        Story = entity.StoryId,
        Goals = goals.OrderBy(g => g.OrderIndex).Select(ToGoalModel).ToArray(),
    };
}
