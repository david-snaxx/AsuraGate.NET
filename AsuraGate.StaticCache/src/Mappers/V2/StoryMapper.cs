using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class StoryMapper
{
    public static StoryEntity ToStoryEntity(Story story) => new StoryEntity()
    {
        Id = story.Id,
        Season = story.Season,
        Name = story.Name,
        Description = story.Description,
        Timeline = story.Timeline,
        Level = story.Level,
        Order = story.Order
    };

    public static IEnumerable<StoryChapterEntity> ToChapterEntities(Story story) =>
        story.Chapters.Select((chapter, index) => new StoryChapterEntity()
        {
            StoryId = story.Id,
            OrderIndex = index,
            Name = chapter.Name
        });

    public static IEnumerable<StoryRaceEntity> ToRaceEntities(Story story) =>
        story.Races.Select(race => new StoryRaceEntity()
        {
            StoryId = story.Id,
            Race = race
        });

    public static IEnumerable<StoryFlagEntity> ToFlagEntities(Story story) =>
        story.Flags.Select(flag => new StoryFlagEntity()
        {
            StoryId = story.Id,
            Flag = flag
        });

    public static Story ToModel(
        StoryEntity entity,
        IEnumerable<StoryChapterEntity> chapterEntities,
        IEnumerable<StoryRaceEntity> raceEntities,
        IEnumerable<StoryFlagEntity> flagEntities) => new Story()
    {
        Id = entity.Id,
        Season = entity.Season,
        Name = entity.Name,
        Description = entity.Description,
        Timeline = entity.Timeline,
        Level = entity.Level,
        Order = entity.Order,
        Chapters = chapterEntities.OrderBy(chapter => chapter.OrderIndex).Select(chapter => new StoryChapter() { Name = chapter.Name }).ToArray(),
        Races = raceEntities.Select(race => race.Race).ToArray(),
        Flags = flagEntities.Select(flag => flag.Flag).ToArray()
    };
}
