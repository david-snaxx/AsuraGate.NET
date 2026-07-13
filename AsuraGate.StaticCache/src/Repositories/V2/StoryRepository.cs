using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class StoryRepository :
    IStaticCacheRepository<Story, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public StoryRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Story?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<StoryEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var chapterEntities = await _database.Connection.Table<StoryChapterEntity>().Where(chapter => chapter.StoryId == id).ToListAsync();
        var raceEntities = await _database.Connection.Table<StoryRaceEntity>().Where(race => race.StoryId == id).ToListAsync();
        var flagEntities = await _database.Connection.Table<StoryFlagEntity>().Where(flag => flag.StoryId == id).ToListAsync();
        return StoryMapper.ToModel(entity, chapterEntities, raceEntities, flagEntities);
    }

    public async Task<IEnumerable<Story>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<StoryEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var chapterEntities = await _database.Connection
            .Table<StoryChapterEntity>()
            .Where(chapter => idList.Contains(chapter.StoryId))
            .ToListAsync();
        var raceEntities = await _database.Connection
            .Table<StoryRaceEntity>()
            .Where(race => idList.Contains(race.StoryId))
            .ToListAsync();
        var flagEntities = await _database.Connection
            .Table<StoryFlagEntity>()
            .Where(flag => idList.Contains(flag.StoryId))
            .ToListAsync();

        return entities.Select(entity => StoryMapper.ToModel(
            entity,
            chapterEntities.Where(chapter => chapter.StoryId == entity.Id),
            raceEntities.Where(race => race.StoryId == entity.Id),
            flagEntities.Where(flag => flag.StoryId == entity.Id)));
    }

    public async Task<IEnumerable<Story>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<StoryEntity>().ToListAsync();
        var chapterEntities = await _database.Connection.Table<StoryChapterEntity>().ToListAsync();
        var raceEntities = await _database.Connection.Table<StoryRaceEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<StoryFlagEntity>().ToListAsync();

        return entities.Select(entity => StoryMapper.ToModel(
            entity,
            chapterEntities.Where(chapter => chapter.StoryId == entity.Id),
            raceEntities.Where(race => race.StoryId == entity.Id),
            flagEntities.Where(flag => flag.StoryId == entity.Id)));
    }

    public async Task<IEnumerable<int>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<StoryEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(Story story) => UpsertAllAsync([story]);

    public Task UpsertAllAsync(IEnumerable<Story> stories) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var story in stories)
        {
            connection.InsertOrReplace(StoryMapper.ToStoryEntity(story));
            connection.Table<StoryChapterEntity>().Delete(chapter => chapter.StoryId == story.Id);
            connection.InsertAll(StoryMapper.ToChapterEntities(story));
            connection.Table<StoryRaceEntity>().Delete(race => race.StoryId == story.Id);
            connection.InsertAll(StoryMapper.ToRaceEntities(story));
            connection.Table<StoryFlagEntity>().Delete(flag => flag.StoryId == story.Id);
            connection.InsertAll(StoryMapper.ToFlagEntities(story));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<StoryChapterEntity>().Delete(chapter => chapter.StoryId == id);
        connection.Table<StoryRaceEntity>().Delete(race => race.StoryId == id);
        connection.Table<StoryFlagEntity>().Delete(flag => flag.StoryId == id);
        connection.Delete<StoryEntity>(id);
    });
}
