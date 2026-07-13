using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class ProfessionRepository :
    IStaticCacheRepository<Profession, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public ProfessionRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Profession?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<ProfessionEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var specializationEntities = await _database.Connection.Table<ProfessionSpecializationEntity>().Where(specialization => specialization.ProfessionId == id).ToListAsync();
        var flagEntities = await _database.Connection.Table<ProfessionFlagEntity>().Where(flag => flag.ProfessionId == id).ToListAsync();
        var skillEntities = await _database.Connection.Table<ProfessionSkillEntity>().Where(skill => skill.ProfessionId == id).ToListAsync();
        var skillPaletteEntities = await _database.Connection.Table<ProfessionSkillPaletteEntity>().Where(pair => pair.ProfessionId == id).ToListAsync();
        var trainingEntities = await _database.Connection.Table<ProfessionTrainingEntity>().Where(training => training.ProfessionId == id).ToListAsync();
        var trainingTrackEntryEntities = await _database.Connection.Table<ProfessionTrainingTrackEntryEntity>().Where(entry => entry.ProfessionId == id).ToListAsync();
        var weaponEntities = await _database.Connection.Table<ProfessionWeaponEntity>().Where(weapon => weapon.ProfessionId == id).ToListAsync();
        var weaponFlagEntities = await _database.Connection.Table<ProfessionWeaponFlagEntity>().Where(flag => flag.ProfessionId == id).ToListAsync();
        var weaponSkillEntities = await _database.Connection.Table<ProfessionWeaponSkillEntity>().Where(skill => skill.ProfessionId == id).ToListAsync();

        return ProfessionMapper.ToModel(
            entity,
            specializationEntities,
            flagEntities,
            skillEntities,
            skillPaletteEntities,
            trainingEntities,
            trainingTrackEntryEntities,
            weaponEntities,
            weaponFlagEntities,
            weaponSkillEntities);
    }

    public async Task<IEnumerable<Profession>> GetManyAsync(IEnumerable<string> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<ProfessionEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var specializationEntities = await _database.Connection
            .Table<ProfessionSpecializationEntity>()
            .Where(specialization => idList.Contains(specialization.ProfessionId))
            .ToListAsync();
        var flagEntities = await _database.Connection
            .Table<ProfessionFlagEntity>()
            .Where(flag => idList.Contains(flag.ProfessionId))
            .ToListAsync();
        var skillEntities = await _database.Connection
            .Table<ProfessionSkillEntity>()
            .Where(skill => idList.Contains(skill.ProfessionId))
            .ToListAsync();
        var skillPaletteEntities = await _database.Connection
            .Table<ProfessionSkillPaletteEntity>()
            .Where(pair => idList.Contains(pair.ProfessionId))
            .ToListAsync();
        var trainingEntities = await _database.Connection
            .Table<ProfessionTrainingEntity>()
            .Where(training => idList.Contains(training.ProfessionId))
            .ToListAsync();
        var trainingTrackEntryEntities = await _database.Connection
            .Table<ProfessionTrainingTrackEntryEntity>()
            .Where(entry => idList.Contains(entry.ProfessionId))
            .ToListAsync();
        var weaponEntities = await _database.Connection
            .Table<ProfessionWeaponEntity>()
            .Where(weapon => idList.Contains(weapon.ProfessionId))
            .ToListAsync();
        var weaponFlagEntities = await _database.Connection
            .Table<ProfessionWeaponFlagEntity>()
            .Where(flag => idList.Contains(flag.ProfessionId))
            .ToListAsync();
        var weaponSkillEntities = await _database.Connection
            .Table<ProfessionWeaponSkillEntity>()
            .Where(skill => idList.Contains(skill.ProfessionId))
            .ToListAsync();

        return entities.Select(entity => ProfessionMapper.ToModel(
            entity,
            specializationEntities.Where(specialization => specialization.ProfessionId == entity.Id),
            flagEntities.Where(flag => flag.ProfessionId == entity.Id),
            skillEntities.Where(skill => skill.ProfessionId == entity.Id),
            skillPaletteEntities.Where(pair => pair.ProfessionId == entity.Id),
            trainingEntities.Where(training => training.ProfessionId == entity.Id),
            trainingTrackEntryEntities.Where(entry => entry.ProfessionId == entity.Id),
            weaponEntities.Where(weapon => weapon.ProfessionId == entity.Id),
            weaponFlagEntities.Where(flag => flag.ProfessionId == entity.Id),
            weaponSkillEntities.Where(skill => skill.ProfessionId == entity.Id)));
    }

    public async Task<IEnumerable<Profession>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<ProfessionEntity>().ToListAsync();
        var specializationEntities = await _database.Connection.Table<ProfessionSpecializationEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<ProfessionFlagEntity>().ToListAsync();
        var skillEntities = await _database.Connection.Table<ProfessionSkillEntity>().ToListAsync();
        var skillPaletteEntities = await _database.Connection.Table<ProfessionSkillPaletteEntity>().ToListAsync();
        var trainingEntities = await _database.Connection.Table<ProfessionTrainingEntity>().ToListAsync();
        var trainingTrackEntryEntities = await _database.Connection.Table<ProfessionTrainingTrackEntryEntity>().ToListAsync();
        var weaponEntities = await _database.Connection.Table<ProfessionWeaponEntity>().ToListAsync();
        var weaponFlagEntities = await _database.Connection.Table<ProfessionWeaponFlagEntity>().ToListAsync();
        var weaponSkillEntities = await _database.Connection.Table<ProfessionWeaponSkillEntity>().ToListAsync();

        return entities.Select(entity => ProfessionMapper.ToModel(
            entity,
            specializationEntities.Where(specialization => specialization.ProfessionId == entity.Id),
            flagEntities.Where(flag => flag.ProfessionId == entity.Id),
            skillEntities.Where(skill => skill.ProfessionId == entity.Id),
            skillPaletteEntities.Where(pair => pair.ProfessionId == entity.Id),
            trainingEntities.Where(training => training.ProfessionId == entity.Id),
            trainingTrackEntryEntities.Where(entry => entry.ProfessionId == entity.Id),
            weaponEntities.Where(weapon => weapon.ProfessionId == entity.Id),
            weaponFlagEntities.Where(flag => flag.ProfessionId == entity.Id),
            weaponSkillEntities.Where(skill => skill.ProfessionId == entity.Id)));
    }

    public async Task<IEnumerable<string>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<ProfessionEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(Profession profession) => UpsertAllAsync([profession]);

    public Task UpsertAllAsync(IEnumerable<Profession> professions) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var profession in professions)
        {
            connection.InsertOrReplace(ProfessionMapper.ToProfessionEntity(profession));

            connection.Table<ProfessionSpecializationEntity>().Delete(specialization => specialization.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToSpecializationEntities(profession));

            connection.Table<ProfessionFlagEntity>().Delete(flag => flag.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToFlagEntities(profession));

            connection.Table<ProfessionSkillEntity>().Delete(skill => skill.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToSkillEntities(profession));

            connection.Table<ProfessionSkillPaletteEntity>().Delete(pair => pair.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToSkillPaletteEntities(profession));

            connection.Table<ProfessionTrainingEntity>().Delete(training => training.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToTrainingEntities(profession));

            connection.Table<ProfessionTrainingTrackEntryEntity>().Delete(entry => entry.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToTrainingTrackEntryEntities(profession));

            connection.Table<ProfessionWeaponEntity>().Delete(weapon => weapon.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToWeaponEntities(profession));

            connection.Table<ProfessionWeaponFlagEntity>().Delete(flag => flag.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToWeaponFlagEntities(profession));

            connection.Table<ProfessionWeaponSkillEntity>().Delete(skill => skill.ProfessionId == profession.Id);
            connection.InsertAll(ProfessionMapper.ToWeaponSkillEntities(profession));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<ProfessionSpecializationEntity>().Delete(specialization => specialization.ProfessionId == id);
        connection.Table<ProfessionFlagEntity>().Delete(flag => flag.ProfessionId == id);
        connection.Table<ProfessionSkillEntity>().Delete(skill => skill.ProfessionId == id);
        connection.Table<ProfessionSkillPaletteEntity>().Delete(pair => pair.ProfessionId == id);
        connection.Table<ProfessionTrainingEntity>().Delete(training => training.ProfessionId == id);
        connection.Table<ProfessionTrainingTrackEntryEntity>().Delete(entry => entry.ProfessionId == id);
        connection.Table<ProfessionWeaponEntity>().Delete(weapon => weapon.ProfessionId == id);
        connection.Table<ProfessionWeaponFlagEntity>().Delete(flag => flag.ProfessionId == id);
        connection.Table<ProfessionWeaponSkillEntity>().Delete(skill => skill.ProfessionId == id);
        connection.Delete<ProfessionEntity>(id);
    });
}
