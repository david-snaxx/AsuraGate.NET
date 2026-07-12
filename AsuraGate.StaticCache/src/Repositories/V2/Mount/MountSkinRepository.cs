using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.StaticCache.Entities.V2.Mount;
using AsuraGate.StaticCache.Mappers.V2.Mount;

namespace AsuraGate.StaticCache.Repositories.V2.Mount;

public class MountSkinRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public MountSkinRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<MountSkin?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<MountSkinEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var dyeSlotEntities = await _database.Connection.Table<MountSkinDyeSlotEntity>().Where(slot => slot.MountSkinId == id).ToListAsync();
        return MountSkinMapper.ToModel(entity, dyeSlotEntities);
    }

    public async Task<IEnumerable<MountSkin>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<MountSkinEntity>().ToListAsync();
        var dyeSlotEntities = await _database.Connection.Table<MountSkinDyeSlotEntity>().ToListAsync();

        return entities.Select(entity => MountSkinMapper.ToModel(entity, dyeSlotEntities.Where(slot => slot.MountSkinId == entity.Id)));
    }

    public Task UpsertAsync(MountSkin mountSkin) => UpsertAllAsync([mountSkin]);

    public Task UpsertAllAsync(IEnumerable<MountSkin> mountSkins) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var mountSkin in mountSkins)
        {
            connection.InsertOrReplace(MountSkinMapper.ToMountSkinEntity(mountSkin));
            connection.Table<MountSkinDyeSlotEntity>().Delete(slot => slot.MountSkinId == mountSkin.Id);
            connection.InsertAll(MountSkinMapper.ToDyeSlotEntities(mountSkin));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<MountSkinDyeSlotEntity>().Delete(slot => slot.MountSkinId == id);
        connection.Delete<MountSkinEntity>(id);
    });
}
