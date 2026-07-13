using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.StaticCache.Entities.V2.Mount;
using AsuraGate.StaticCache.Mappers.V2.Mount;

namespace AsuraGate.StaticCache.Repositories.V2.Mount;

public class MountTypeRepository :
    IStaticCacheRepository<MountType, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public MountTypeRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<MountType?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<MountTypeEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var skinEntities = await _database.Connection.Table<MountTypeSkinEntity>().Where(skin => skin.MountTypeId == id).ToListAsync();
        var skillEntities = await _database.Connection.Table<MountTypeSkillEntity>().Where(skill => skill.MountTypeId == id).ToListAsync();
        return MountTypeMapper.ToModel(entity, skinEntities, skillEntities);
    }

    public async Task<IEnumerable<MountType>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<MountTypeEntity>().ToListAsync();
        var skinEntities = await _database.Connection.Table<MountTypeSkinEntity>().ToListAsync();
        var skillEntities = await _database.Connection.Table<MountTypeSkillEntity>().ToListAsync();

        return entities.Select(entity => MountTypeMapper.ToModel(
            entity,
            skinEntities.Where(skin => skin.MountTypeId == entity.Id),
            skillEntities.Where(skill => skill.MountTypeId == entity.Id)));
    }

    public Task UpsertAsync(MountType mountType) => UpsertAllAsync([mountType]);

    public Task UpsertAllAsync(IEnumerable<MountType> mountTypes) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var mountType in mountTypes)
        {
            connection.InsertOrReplace(MountTypeMapper.ToMountTypeEntity(mountType));
            connection.Table<MountTypeSkinEntity>().Delete(skin => skin.MountTypeId == mountType.Id);
            connection.InsertAll(MountTypeMapper.ToSkinEntities(mountType));
            connection.Table<MountTypeSkillEntity>().Delete(skill => skill.MountTypeId == mountType.Id);
            connection.InsertAll(MountTypeMapper.ToSkillEntities(mountType));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<MountTypeSkinEntity>().Delete(skin => skin.MountTypeId == id);
        connection.Table<MountTypeSkillEntity>().Delete(skill => skill.MountTypeId == id);
        connection.Delete<MountTypeEntity>(id);
    });
}
