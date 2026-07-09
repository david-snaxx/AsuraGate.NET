namespace AsuraGate.Fetch.Constant;

/// <summary>
/// Defines string constants for GW2 API schema versions.
/// Last updated 2026-06-30 where latest = V2025_08_29.
/// 
/// See: <see href="https://api.guildwars2.com/v2.json?v=latest">https://api.guildwars2.com/v2.json?v=latest</see>
/// for the current state of the API including all supported schema versions.
/// </summary>
public class Gw2ApiSchemaVersion
{
    /// <summary>
    /// The latest schema version this library supports.
    /// Remove `mount` from `/v2/mounts/skins`
    /// </summary>
    public const string Latest = "latest";
    
    /// <summary>
    /// Remove `mount` from `/v2/mounts/skins`
    /// </summary>
    public const string V2025_08_29 = "2025-08-29T01:00:00.000Z";
    
    /// <summary>
    /// Add wvw `team_id` to `/v2/account` to show world restructuring team id and move wvw fields into `wvw`
    /// </summary>
    public const string V2024_07_20 = "2024-07-20T01:00:00.000Z";
    
    /// <summary>
    /// Change `/v2/achievements/categories` to show tomorrow's dailies and show access requirements for relevant achievements.
    /// </summary>
    public const string V2022_03_23 = "2022-03-23T19:00:00.000Z";
    
    /// <summary>
    /// Change `ingredients` to `item_ingredients` and add `currency_ingredients` to `/v2/recipes`.
    /// </summary>
    public const string V2022_03_09 = "2022-03-09T02:00:00.000Z";
    
    /// <summary>
    /// Add `EquippedFromLegendaryArmory` and `LegendaryArmory` values to `equipment[i].location` field
    /// </summary>
    public const string V2021_07_15 = "2021-07-15T13:00:00.000Z";
    
    /// <summary>
    /// Move `equipment_pvp` under `equipment_tabs` in `/v2/characters/:id`
    /// </summary>
    public const string V2021_04_06 = "2021-04-06T21:00:00.000Z";
    
    /// <summary>
    /// Change the type of `details.secondary_suffix_item_id` from `/v2/items` to be an optional int.
    /// </summary>
    public const string V2020_11_17 = "2020-11-17T00:30:00.000Z";
    
    /// <summary>
    /// Add `code` and `skills_by_palette` to `/v2/professions`. Add `code` to `/v2/legends`. Add `build_storage_slots`
    /// to `/v2/account`. Add `build_tabs_unlocked`, `active_build_tab`, `build_tabs`, `equipment_tabs_unlocked`,
    /// `active_equipment_tab` and `equipment_tabs` to `/v2/characters/:id`. Add `equipment[i].location` and
    /// `equipment[i].tabs` to `/v2/characters/:id`. Remove `skills` and `specializations` from `/v2/characters/:id`.
    /// </summary>
    public const string V2019_12_19 = "2019-12-19T00:00:00.000Z";
    
    /// <summary>
    /// Change `/v2/tokeninfo` to show subtoken information when one is provided.
    /// </summary>
    public const string V2019_05_22 = "2019-05-22T00:00:00.000Z";
    
    /// <summary>
    /// Add `schema_versions` to `/v2.json`
    /// </summary>
    public const string V2019_05_21 = "2019-05-21T23:00:00.000Z";
    
    /// <summary>
    /// Change the `access_required` field in `v2/achievements/daily` to show product conditions
    /// </summary>
    public const string V2019_05_16 = "2019-05-16T00:00:00.000Z";
    
    /// <summary>
    /// Change `/v2/account/home/cats` to just list cat ids
    /// </summary>
    public const string V2019_03_22 = "2019-03-22T00:00:00.000Z";
    
    /// <summary>
    /// Add `last_modified` field to account and character records.
    /// </summary>
    public const string V2019_02_21 = "2019-02-21T00:00:00.000Z";
}