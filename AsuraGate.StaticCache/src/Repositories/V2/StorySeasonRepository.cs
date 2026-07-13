using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class StorySeasonRepository :
    IStaticCacheRepository<StorySeason, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public StorySeasonRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<StorySeason?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<StorySeasonEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var storyEntities = await _database.Connection.Table<StorySeasonStoryEntity>().Where(story => story.StorySeasonId == id).ToListAsync();
        return StorySeasonMapper.ToModel(entity, storyEntities);
    }

    public async Task<IEnumerable<StorySeason>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<StorySeasonEntity>().ToListAsync();
        var storyEntities = await _database.Connection.Table<StorySeasonStoryEntity>().ToListAsync();

        return entities.Select(entity => StorySeasonMapper.ToModel(entity, storyEntities.Where(story => story.StorySeasonId == entity.Id)));
    }

    public Task UpsertAsync(StorySeason storySeason) => UpsertAllAsync([storySeason]);

    public Task UpsertAllAsync(IEnumerable<StorySeason> storySeasons) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var storySeason in storySeasons)
        {
            connection.InsertOrReplace(StorySeasonMapper.ToStorySeasonEntity(storySeason));
            connection.Table<StorySeasonStoryEntity>().Delete(story => story.StorySeasonId == storySeason.Id);
            connection.InsertAll(StorySeasonMapper.ToStoryEntities(storySeason));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<StorySeasonStoryEntity>().Delete(story => story.StorySeasonId == id);
        connection.Delete<StorySeasonEntity>(id);
    });
}
