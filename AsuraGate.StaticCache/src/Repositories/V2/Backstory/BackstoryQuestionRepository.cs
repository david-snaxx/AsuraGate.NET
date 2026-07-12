using AsuraGate.Spec.Models.V2.Backstory;
using AsuraGate.StaticCache.Entities.V2.Backstory;
using AsuraGate.StaticCache.Mappers.V2.Backstory;

namespace AsuraGate.StaticCache.Repositories.V2.Backstory;

public class BackstoryQuestionRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public BackstoryQuestionRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<BackstoryQuestion?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<BackstoryQuestionEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var answerEntities = await _database.Connection.Table<BackstoryQuestionAnswerEntity>().Where(answer => answer.BackstoryQuestionId == id).ToListAsync();
        var raceEntities = await _database.Connection.Table<BackstoryQuestionRaceEntity>().Where(race => race.BackstoryQuestionId == id).ToListAsync();
        var professionEntities = await _database.Connection.Table<BackstoryQuestionProfessionEntity>().Where(profession => profession.BackstoryQuestionId == id).ToListAsync();
        return BackstoryQuestionMapper.ToModel(entity, answerEntities, raceEntities, professionEntities);
    }

    public async Task<IEnumerable<BackstoryQuestion>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<BackstoryQuestionEntity>().ToListAsync();
        var answerEntities = await _database.Connection.Table<BackstoryQuestionAnswerEntity>().ToListAsync();
        var raceEntities = await _database.Connection.Table<BackstoryQuestionRaceEntity>().ToListAsync();
        var professionEntities = await _database.Connection.Table<BackstoryQuestionProfessionEntity>().ToListAsync();

        return entities.Select(entity => BackstoryQuestionMapper.ToModel(
            entity,
            answerEntities.Where(answer => answer.BackstoryQuestionId == entity.Id),
            raceEntities.Where(race => race.BackstoryQuestionId == entity.Id),
            professionEntities.Where(profession => profession.BackstoryQuestionId == entity.Id)));
    }

    public Task UpsertAsync(BackstoryQuestion question) => UpsertAllAsync([question]);

    public Task UpsertAllAsync(IEnumerable<BackstoryQuestion> questions) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var question in questions)
        {
            connection.InsertOrReplace(BackstoryQuestionMapper.ToBackstoryQuestionEntity(question));
            connection.Table<BackstoryQuestionAnswerEntity>().Delete(answer => answer.BackstoryQuestionId == question.Id);
            connection.InsertAll(BackstoryQuestionMapper.ToAnswerEntities(question));
            connection.Table<BackstoryQuestionRaceEntity>().Delete(race => race.BackstoryQuestionId == question.Id);
            connection.InsertAll(BackstoryQuestionMapper.ToRaceEntities(question));
            connection.Table<BackstoryQuestionProfessionEntity>().Delete(profession => profession.BackstoryQuestionId == question.Id);
            connection.InsertAll(BackstoryQuestionMapper.ToProfessionEntities(question));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<BackstoryQuestionAnswerEntity>().Delete(answer => answer.BackstoryQuestionId == id);
        connection.Table<BackstoryQuestionRaceEntity>().Delete(race => race.BackstoryQuestionId == id);
        connection.Table<BackstoryQuestionProfessionEntity>().Delete(profession => profession.BackstoryQuestionId == id);
        connection.Delete<BackstoryQuestionEntity>(id);
    });
}
