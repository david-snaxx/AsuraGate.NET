using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class ApiFileRepository : StaticRepository<ApiFile, ApiFileEntity, string>
{
    public ApiFileRepository(Gw2ApiPersistenceDatabase database)
        : base(database, ApiFileMapper.ToEntity, ApiFileMapper.ToModel)
    {
    }
}
