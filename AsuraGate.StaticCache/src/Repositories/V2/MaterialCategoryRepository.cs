using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class MaterialCategoryRepository :
    IStaticCacheRepository<MaterialCategory, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public MaterialCategoryRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<MaterialCategory?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<MaterialCategoryEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var itemEntities = await _database.Connection.Table<MaterialCategoryItemEntity>().Where(item => item.MaterialCategoryId == id).ToListAsync();
        return MaterialCategoryMapper.ToModel(entity, itemEntities);
    }

    public async Task<IEnumerable<MaterialCategory>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<MaterialCategoryEntity>().ToListAsync();
        var itemEntities = await _database.Connection.Table<MaterialCategoryItemEntity>().ToListAsync();

        return entities.Select(entity => MaterialCategoryMapper.ToModel(entity, itemEntities.Where(item => item.MaterialCategoryId == entity.Id)));
    }

    public Task UpsertAsync(MaterialCategory materialCategory) => UpsertAllAsync([materialCategory]);

    public Task UpsertAllAsync(IEnumerable<MaterialCategory> materialCategories) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var materialCategory in materialCategories)
        {
            connection.InsertOrReplace(MaterialCategoryMapper.ToMaterialCategoryEntity(materialCategory));
            connection.Table<MaterialCategoryItemEntity>().Delete(item => item.MaterialCategoryId == materialCategory.Id);
            connection.InsertAll(MaterialCategoryMapper.ToItemEntities(materialCategory));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<MaterialCategoryItemEntity>().Delete(item => item.MaterialCategoryId == id);
        connection.Delete<MaterialCategoryEntity>(id);
    });
}
