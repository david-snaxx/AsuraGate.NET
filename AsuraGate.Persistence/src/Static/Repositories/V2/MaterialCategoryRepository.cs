using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class MaterialCategoryRepository : StaticRepository<MaterialCategory, MaterialCategoryEntity, int>
{
    public MaterialCategoryRepository(Gw2ApiPersistenceDatabase database)
        : base(database, MaterialCategoryMapper.ToEntity, MaterialCategoryMapper.ToModel)
    {
    }
}
