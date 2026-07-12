using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class SkillRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public SkillRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Skill?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<SkillEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var professionEntities = await _database.Connection.Table<SkillProfessionEntity>().Where(profession => profession.SkillId == id).ToListAsync();
        var categoryEntities = await _database.Connection.Table<SkillCategoryEntity>().Where(category => category.SkillId == id).ToListAsync();
        var flagEntities = await _database.Connection.Table<SkillFlagEntity>().Where(flag => flag.SkillId == id).ToListAsync();
        var relatedSkillEntities = await _database.Connection.Table<SkillRelatedSkillEntity>().Where(related => related.SkillId == id).ToListAsync();
        var factEntities = await _database.Connection.Table<SkillFactEntity>().Where(fact => fact.SkillId == id).ToListAsync();

        return SkillMapper.ToModel(entity, professionEntities, categoryEntities, flagEntities, relatedSkillEntities, factEntities);
    }

    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<SkillEntity>().ToListAsync();
        var professionEntities = await _database.Connection.Table<SkillProfessionEntity>().ToListAsync();
        var categoryEntities = await _database.Connection.Table<SkillCategoryEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<SkillFlagEntity>().ToListAsync();
        var relatedSkillEntities = await _database.Connection.Table<SkillRelatedSkillEntity>().ToListAsync();
        var factEntities = await _database.Connection.Table<SkillFactEntity>().ToListAsync();

        return entities.Select(entity => SkillMapper.ToModel(
            entity,
            professionEntities.Where(profession => profession.SkillId == entity.Id),
            categoryEntities.Where(category => category.SkillId == entity.Id),
            flagEntities.Where(flag => flag.SkillId == entity.Id),
            relatedSkillEntities.Where(related => related.SkillId == entity.Id),
            factEntities.Where(fact => fact.SkillId == entity.Id)));
    }

    public Task UpsertAsync(Skill skill) => UpsertAllAsync([skill]);

    public Task UpsertAllAsync(IEnumerable<Skill> skills) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var skill in skills)
        {
            connection.InsertOrReplace(SkillMapper.ToSkillEntity(skill));

            connection.Table<SkillProfessionEntity>().Delete(profession => profession.SkillId == skill.Id);
            connection.InsertAll(SkillMapper.ToProfessionEntities(skill));

            connection.Table<SkillCategoryEntity>().Delete(category => category.SkillId == skill.Id);
            connection.InsertAll(SkillMapper.ToCategoryEntities(skill));

            connection.Table<SkillFlagEntity>().Delete(flag => flag.SkillId == skill.Id);
            connection.InsertAll(SkillMapper.ToFlagEntities(skill));

            connection.Table<SkillRelatedSkillEntity>().Delete(related => related.SkillId == skill.Id);
            connection.InsertAll(SkillMapper.ToRelatedSkillEntities(skill));

            connection.Table<SkillFactEntity>().Delete(fact => fact.SkillId == skill.Id);
            connection.InsertAll(SkillMapper.ToFactEntities(skill));
            connection.InsertAll(SkillMapper.ToTraitedFactEntities(skill));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<SkillProfessionEntity>().Delete(profession => profession.SkillId == id);
        connection.Table<SkillCategoryEntity>().Delete(category => category.SkillId == id);
        connection.Table<SkillFlagEntity>().Delete(flag => flag.SkillId == id);
        connection.Table<SkillRelatedSkillEntity>().Delete(related => related.SkillId == id);
        connection.Table<SkillFactEntity>().Delete(fact => fact.SkillId == id);
        connection.Delete<SkillEntity>(id);
    });
}
