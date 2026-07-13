using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class MailCarrierRepository :
    IStaticCacheRepository<MailCarrier, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public MailCarrierRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<MailCarrier?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<MailCarrierEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var unlockItemEntities = await _database.Connection.Table<MailCarrierUnlockItemEntity>().Where(item => item.MailCarrierId == id).ToListAsync();
        var flagEntities = await _database.Connection.Table<MailCarrierFlagEntity>().Where(flag => flag.MailCarrierId == id).ToListAsync();
        return MailCarrierMapper.ToModel(entity, unlockItemEntities, flagEntities);
    }

    public async Task<IEnumerable<MailCarrier>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<MailCarrierEntity>().ToListAsync();
        var unlockItemEntities = await _database.Connection.Table<MailCarrierUnlockItemEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<MailCarrierFlagEntity>().ToListAsync();

        return entities.Select(entity => MailCarrierMapper.ToModel(
            entity,
            unlockItemEntities.Where(item => item.MailCarrierId == entity.Id),
            flagEntities.Where(flag => flag.MailCarrierId == entity.Id)));
    }

    public Task UpsertAsync(MailCarrier mailCarrier) => UpsertAllAsync([mailCarrier]);

    public Task UpsertAllAsync(IEnumerable<MailCarrier> mailCarriers) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var mailCarrier in mailCarriers)
        {
            connection.InsertOrReplace(MailCarrierMapper.ToMailCarrierEntity(mailCarrier));
            connection.Table<MailCarrierUnlockItemEntity>().Delete(item => item.MailCarrierId == mailCarrier.Id);
            connection.InsertAll(MailCarrierMapper.ToUnlockItemEntities(mailCarrier));
            connection.Table<MailCarrierFlagEntity>().Delete(flag => flag.MailCarrierId == mailCarrier.Id);
            connection.InsertAll(MailCarrierMapper.ToFlagEntities(mailCarrier));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<MailCarrierUnlockItemEntity>().Delete(item => item.MailCarrierId == id);
        connection.Table<MailCarrierFlagEntity>().Delete(flag => flag.MailCarrierId == id);
        connection.Delete<MailCarrierEntity>(id);
    });
}
