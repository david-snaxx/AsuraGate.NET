using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class FinisherRepository :
    IStaticCacheRepository<Finisher, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public FinisherRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Finisher?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<FinisherEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var unlockItemEntities = await _database.Connection.Table<FinisherUnlockItemEntity>().Where(item => item.FinisherId == id).ToListAsync();
        return FinisherMapper.ToModel(entity, unlockItemEntities);
    }

    public async Task<IEnumerable<Finisher>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<FinisherEntity>().ToListAsync();
        var unlockItemEntities = await _database.Connection.Table<FinisherUnlockItemEntity>().ToListAsync();

        return entities.Select(entity => FinisherMapper.ToModel(entity, unlockItemEntities.Where(item => item.FinisherId == entity.Id)));
    }

    public Task UpsertAsync(Finisher finisher) => UpsertAllAsync([finisher]);

    public Task UpsertAllAsync(IEnumerable<Finisher> finishers) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var finisher in finishers)
        {
            connection.InsertOrReplace(FinisherMapper.ToFinisherEntity(finisher));
            connection.Table<FinisherUnlockItemEntity>().Delete(item => item.FinisherId == finisher.Id);
            connection.InsertAll(FinisherMapper.ToUnlockItemEntities(finisher));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<FinisherUnlockItemEntity>().Delete(item => item.FinisherId == id);
        connection.Delete<FinisherEntity>(id);
    });
}
