using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class PetRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public PetRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Pet?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<PetEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var skillEntities = await _database.Connection.Table<PetSkillEntity>().Where(skill => skill.PetId == id).ToListAsync();
        return PetMapper.ToModel(entity, skillEntities);
    }

    public async Task<IEnumerable<Pet>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<PetEntity>().ToListAsync();
        var skillEntities = await _database.Connection.Table<PetSkillEntity>().ToListAsync();

        return entities.Select(entity => PetMapper.ToModel(entity, skillEntities.Where(skill => skill.PetId == entity.Id)));
    }

    public Task UpsertAsync(Pet pet) => UpsertAllAsync([pet]);

    public Task UpsertAllAsync(IEnumerable<Pet> pets) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var pet in pets)
        {
            connection.InsertOrReplace(PetMapper.ToPetEntity(pet));
            connection.Table<PetSkillEntity>().Delete(skill => skill.PetId == pet.Id);
            connection.InsertAll(PetMapper.ToSkillEntities(pet));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<PetSkillEntity>().Delete(skill => skill.PetId == id);
        connection.Delete<PetEntity>(id);
    });
}
