using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Story"/> to <see cref="StoryEntity"/>.
/// </summary>
public static class StoryMapper
{
    public static StoryEntity ToEntity(Story story) => new StoryEntity()
    {
        Id = story.Id,
        SeasonId = story.Season,
        Name = story.Name,
        Description = story.Description,
        Timeline = story.Timeline,
        Level = story.Level,
        Order = story.Order,
    };

    public static IReadOnlyList<StoryChapterEntity> ToChapterEntities(Story story) =>
        story.Chapters.Select((chapter, index) => new StoryChapterEntity() { StoryId = story.Id, OrderIndex = index, Name = chapter.Name }).ToList();

    public static IReadOnlyList<StoryRaceEntity> ToRaceEntities(Story story) =>
        story.Races.Select(race => new StoryRaceEntity() { StoryId = story.Id, Race = race }).ToList();

    public static IReadOnlyList<StoryFlagEntity> ToFlagEntities(Story story) =>
        story.Flags.Select(flag => new StoryFlagEntity() { StoryId = story.Id, Flag = flag }).ToList();

    public static Story ToModel(StoryEntity entity, IEnumerable<StoryChapterEntity> chapters, IEnumerable<string> races, IEnumerable<string> flags) => new Story()
    {
        Id = entity.Id,
        Season = entity.SeasonId,
        Name = entity.Name,
        Description = entity.Description,
        Timeline = entity.Timeline,
        Level = entity.Level,
        Order = entity.Order,
        Chapters = chapters.OrderBy(c => c.OrderIndex).Select(c => new StoryChapter() { Name = c.Name }).ToArray(),
        Races = races.ToArray(),
        Flags = flags.ToArray(),
    };
}
