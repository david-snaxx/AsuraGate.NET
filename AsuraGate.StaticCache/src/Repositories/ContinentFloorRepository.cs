using SQLite;
using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;
using AsuraGate.StaticCache.Mappers;

namespace AsuraGate.StaticCache.Repositories;

/// <summary>
/// Reference implementation of the "delete the existing subtree, then insert a fresh one" upsert pattern for
/// aggregates with nested children. <see cref="ContinentFloor"/> is a good example to learn the shape from
/// because it's deep — floor -> region -> map -> (god shrines / POIs / tasks / skill challenges / sectors /
/// adventures / mastery points) — so it exercises both halves of the pattern: cascading a delete down several
/// levels, and re-inserting a fresh tree while threading assigned ids down through the same levels.
///
/// Only <see cref="ContinentFloorEntity"/> itself has a DB-assigned id (its primary key isn't the API's floor
/// number, see the entity's own docs for why); everything below it already carries a real API id, so those
/// levels use their own id directly and don't need anything captured back from the database.
/// </summary>
public static class ContinentFloorRepository
{
    /// <summary>
    /// Replaces whatever is currently stored for (<paramref name="continentId"/>, <c>floor.Id</c>) — root row
    /// and every descendant — with the freshly-fetched <paramref name="floor"/>. Safe to call repeatedly for
    /// the same floor: additions, edits, and removals anywhere in the tree are all handled correctly, because
    /// nothing is diffed against what's already there — the whole subtree is simply rebuilt.
    /// </summary>
    public static void Upsert(SQLiteConnection connection, ContinentFloor floor, int continentId)
    {
        connection.RunInTransaction(() =>
        {
            // We need the OLD row's assigned id (if it exists) before we touch anything, so we know what to
            // clear out. InsertOrReplace below will happily overwrite the row itself via the unique index on
            // (continent_id, floor_id) — but it can't know to delete now-stale children we're not about to
            // reinsert (e.g. a POI that existed last time but is gone from this fetch).
            var existing = connection.Table<ContinentFloorEntity>()
                .FirstOrDefault(f => f.ContinentId == continentId && f.FloorId == floor.Id);

            if (existing is not null)
            {
                DeleteDescendants(connection, existing.Id);
            }

            var floorEntity = ContinentFloorMapper.ToEntity(floor, continentId);
            connection.InsertOrReplace(floorEntity);
            // floorEntity.Id is now populated by sqlite-net — either a fresh autoincrement value (first time
            // we've seen this floor) or a new one assigned when the unique-index conflict caused a replace.

            foreach (var region in floor.Regions.Values)
            {
                // Regions/maps/etc. all carry their own API id as primary key, so there's no round-trip needed
                // here — we already know the id before insert, unlike the floor row above.
                var regionEntity = ContinentFloorMapper.ToRegionEntity(region, floorEntity.Id);
                connection.InsertOrReplace(regionEntity);

                foreach (var map in region.Maps.Values)
                {
                    var mapEntity = ContinentFloorMapper.ToMapEntity(map, regionEntity.Id);
                    connection.InsertOrReplace(mapEntity);

                    connection.InsertAll(ContinentFloorMapper.ToGodShrineEntities(map, mapEntity.Id));
                    connection.InsertAll(ContinentFloorMapper.ToPointOfInterestEntities(map, mapEntity.Id));
                    connection.InsertAll(ContinentFloorMapper.ToTaskEntities(map, mapEntity.Id));
                    connection.InsertAll(ContinentFloorMapper.ToSkillChallengeEntities(map, mapEntity.Id));
                    connection.InsertAll(ContinentFloorMapper.ToSectorEntities(map, mapEntity.Id));
                    connection.InsertAll(ContinentFloorMapper.ToAdventureEntities(map, mapEntity.Id));
                    connection.InsertAll(ContinentFloorMapper.ToMasteryPointEntities(map, mapEntity.Id));
                }
            }
        });
    }

    /// <summary>
    /// Deletes everything descending from the floor row at <paramref name="continentFloorId"/>, deepest tables
    /// first. Each statement's subquery walks back up to the floor through the FK chain, so this only needs to
    /// know one id — it doesn't need the caller to have already fetched the regions/maps in between.
    /// </summary>
    private static void DeleteDescendants(SQLiteConnection connection, int continentFloorId)
    {
        const string mapIdsForFloor = """
            SELECT crm.id FROM continent_floor_region_maps crm
            JOIN continent_floor_regions cfr ON cfr.id = crm.region_id
            WHERE cfr.continent_floor_id = ?
            """;

        // These seven all hang directly off a map, so they have to go before the maps themselves disappear.
        connection.Execute($"DELETE FROM continent_floor_region_map_god_shrines WHERE region_map_id IN ({mapIdsForFloor})", continentFloorId);
        connection.Execute($"DELETE FROM continent_floor_region_map_points_of_interest WHERE region_map_id IN ({mapIdsForFloor})", continentFloorId);
        connection.Execute($"DELETE FROM continent_floor_region_map_tasks WHERE region_map_id IN ({mapIdsForFloor})", continentFloorId);
        connection.Execute($"DELETE FROM continent_floor_region_map_skill_challenges WHERE region_map_id IN ({mapIdsForFloor})", continentFloorId);
        connection.Execute($"DELETE FROM continent_floor_region_map_sectors WHERE region_map_id IN ({mapIdsForFloor})", continentFloorId);
        connection.Execute($"DELETE FROM continent_floor_region_map_adventures WHERE region_map_id IN ({mapIdsForFloor})", continentFloorId);
        connection.Execute($"DELETE FROM continent_floor_region_map_mastery_points WHERE region_map_id IN ({mapIdsForFloor})", continentFloorId);

        connection.Execute("""
            DELETE FROM continent_floor_region_maps WHERE region_id IN (
                SELECT id FROM continent_floor_regions WHERE continent_floor_id = ?
            )
            """, continentFloorId);

        connection.Execute("DELETE FROM continent_floor_regions WHERE continent_floor_id = ?", continentFloorId);
    }
}
