using AsuraGate.Spec.Models.V2.Backstory;
using AsuraGate.StaticCache.Entities.V2.Backstory;
using AsuraGate.StaticCache.Mappers.V2.Backstory;

namespace AsuraGate.StaticCache.Repositories.V2.Backstory;

public class BackstoryAnswerRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public BackstoryAnswerRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<BackstoryAnswer?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<BackstoryAnswerEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var professionEntities = await _database.Connection.Table<BackstoryAnswerProfessionEntity>().Where(profession => profession.BackstoryAnswerId == id).ToListAsync();
        var raceEntities = await _database.Connection.Table<BackstoryAnswerRaceEntity>().Where(race => race.BackstoryAnswerId == id).ToListAsync();
        return BackstoryAnswerMapper.ToModel(entity, professionEntities, raceEntities);
    }

    public async Task<IEnumerable<BackstoryAnswer>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<BackstoryAnswerEntity>().ToListAsync();
        var professionEntities = await _database.Connection.Table<BackstoryAnswerProfessionEntity>().ToListAsync();
        var raceEntities = await _database.Connection.Table<BackstoryAnswerRaceEntity>().ToListAsync();

        return entities.Select(entity => BackstoryAnswerMapper.ToModel(
            entity,
            professionEntities.Where(profession => profession.BackstoryAnswerId == entity.Id),
            raceEntities.Where(race => race.BackstoryAnswerId == entity.Id)));
    }

    public Task UpsertAsync(BackstoryAnswer answer) => UpsertAllAsync([answer]);

    public Task UpsertAllAsync(IEnumerable<BackstoryAnswer> answers) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var answer in answers)
        {
            connection.InsertOrReplace(BackstoryAnswerMapper.ToBackstoryAnswerEntity(answer));
            connection.Table<BackstoryAnswerProfessionEntity>().Delete(profession => profession.BackstoryAnswerId == answer.Id);
            connection.InsertAll(BackstoryAnswerMapper.ToProfessionEntities(answer));
            connection.Table<BackstoryAnswerRaceEntity>().Delete(race => race.BackstoryAnswerId == answer.Id);
            connection.InsertAll(BackstoryAnswerMapper.ToRaceEntities(answer));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<BackstoryAnswerProfessionEntity>().Delete(profession => profession.BackstoryAnswerId == id);
        connection.Table<BackstoryAnswerRaceEntity>().Delete(race => race.BackstoryAnswerId == id);
        connection.Delete<BackstoryAnswerEntity>(id);
    });
}
