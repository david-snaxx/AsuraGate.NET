using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class MasteryRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public MasteryRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Mastery?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<MasteryEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var levelEntities = await _database.Connection.Table<MasteryLevelEntity>().Where(level => level.MasteryId == id).ToListAsync();
        return MasteryMapper.ToModel(entity, levelEntities);
    }

    public async Task<IEnumerable<Mastery>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<MasteryEntity>().ToListAsync();
        var levelEntities = await _database.Connection.Table<MasteryLevelEntity>().ToListAsync();

        return entities.Select(entity => MasteryMapper.ToModel(entity, levelEntities.Where(level => level.MasteryId == entity.Id)));
    }

    public Task UpsertAsync(Mastery mastery) => UpsertAllAsync([mastery]);

    public Task UpsertAllAsync(IEnumerable<Mastery> masteries) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var mastery in masteries)
        {
            connection.InsertOrReplace(MasteryMapper.ToMasteryEntity(mastery));
            connection.Table<MasteryLevelEntity>().Delete(level => level.MasteryId == mastery.Id);
            connection.InsertAll(MasteryMapper.ToLevelEntities(mastery));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<MasteryLevelEntity>().Delete(level => level.MasteryId == id);
        connection.Delete<MasteryEntity>(id);
    });
}
