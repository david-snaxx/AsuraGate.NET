using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.ETC.Entities;
using SQLite;

namespace AsuraGate.StaticCache.ETC.Repositories;

public class WorldRepository
{
    public static void Upsert(SQLiteConnection connection, WorldEntity entity)
    {
        WorldEntity existing = connection.Get<WorldEntity>(entity.Id);
        if (existing != null)
        {
            connection.Update(entity);
        }
        else
        {
            connection.Insert(entity);
        }
    }
}