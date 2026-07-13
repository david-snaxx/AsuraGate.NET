using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class ItemRepository :
    IStaticCacheRepository<Item, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public ItemRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Item?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<ItemEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var flagEntities = await _database.Connection.Table<ItemFlagEntity>().Where(flag => flag.ItemId == id).ToListAsync();
        var gameTypeEntities = await _database.Connection.Table<ItemGameTypeEntity>().Where(gameType => gameType.ItemId == id).ToListAsync();
        var restrictionEntities = await _database.Connection.Table<ItemRestrictionEntity>().Where(restriction => restriction.ItemId == id).ToListAsync();
        var upgradePathEntities = await _database.Connection.Table<ItemUpgradePathEntity>().Where(path => path.ItemId == id).ToListAsync();
        var detailsEntity = await _database.Connection.Table<ItemDetailsEntity>().Where(details => details.ItemId == id).FirstOrDefaultAsync();
        var infusionSlotEntities = await _database.Connection.Table<ItemInfusionSlotEntity>().Where(slot => slot.ItemId == id).ToListAsync();
        var infusionSlotFlagEntities = await _database.Connection.Table<ItemInfusionSlotFlagEntity>().Where(flag => flag.ItemId == id).ToListAsync();
        var statChoiceEntities = await _database.Connection.Table<ItemStatChoiceEntity>().Where(choice => choice.ItemId == id).ToListAsync();
        var infixUpgradeAttributeEntities = await _database.Connection.Table<ItemInfixUpgradeAttributeEntity>().Where(attribute => attribute.ItemId == id).ToListAsync();
        var extraRecipeEntities = await _database.Connection.Table<ItemExtraRecipeEntity>().Where(recipe => recipe.ItemId == id).ToListAsync();
        var unlockSkinEntities = await _database.Connection.Table<ItemUnlockSkinEntity>().Where(skin => skin.ItemId == id).ToListAsync();
        var vendorEntities = await _database.Connection.Table<ItemVendorEntity>().Where(vendor => vendor.ItemId == id).ToListAsync();
        var upgradeComponentFlagEntities = await _database.Connection.Table<ItemUpgradeComponentFlagEntity>().Where(flag => flag.ItemId == id).ToListAsync();
        var infusionUpgradeFlagEntities = await _database.Connection.Table<ItemInfusionUpgradeFlagEntity>().Where(flag => flag.ItemId == id).ToListAsync();
        var upgradeComponentBonusEntities = await _database.Connection.Table<ItemUpgradeComponentBonusEntity>().Where(bonus => bonus.ItemId == id).ToListAsync();

        return ItemMapper.ToModel(
            entity,
            flagEntities,
            gameTypeEntities,
            restrictionEntities,
            upgradePathEntities,
            detailsEntity,
            infusionSlotEntities,
            infusionSlotFlagEntities,
            statChoiceEntities,
            infixUpgradeAttributeEntities,
            extraRecipeEntities,
            unlockSkinEntities,
            vendorEntities,
            upgradeComponentFlagEntities,
            infusionUpgradeFlagEntities,
            upgradeComponentBonusEntities);
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<ItemEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<ItemFlagEntity>().ToListAsync();
        var gameTypeEntities = await _database.Connection.Table<ItemGameTypeEntity>().ToListAsync();
        var restrictionEntities = await _database.Connection.Table<ItemRestrictionEntity>().ToListAsync();
        var upgradePathEntities = await _database.Connection.Table<ItemUpgradePathEntity>().ToListAsync();
        var detailsEntities = await _database.Connection.Table<ItemDetailsEntity>().ToListAsync();
        var infusionSlotEntities = await _database.Connection.Table<ItemInfusionSlotEntity>().ToListAsync();
        var infusionSlotFlagEntities = await _database.Connection.Table<ItemInfusionSlotFlagEntity>().ToListAsync();
        var statChoiceEntities = await _database.Connection.Table<ItemStatChoiceEntity>().ToListAsync();
        var infixUpgradeAttributeEntities = await _database.Connection.Table<ItemInfixUpgradeAttributeEntity>().ToListAsync();
        var extraRecipeEntities = await _database.Connection.Table<ItemExtraRecipeEntity>().ToListAsync();
        var unlockSkinEntities = await _database.Connection.Table<ItemUnlockSkinEntity>().ToListAsync();
        var vendorEntities = await _database.Connection.Table<ItemVendorEntity>().ToListAsync();
        var upgradeComponentFlagEntities = await _database.Connection.Table<ItemUpgradeComponentFlagEntity>().ToListAsync();
        var infusionUpgradeFlagEntities = await _database.Connection.Table<ItemInfusionUpgradeFlagEntity>().ToListAsync();
        var upgradeComponentBonusEntities = await _database.Connection.Table<ItemUpgradeComponentBonusEntity>().ToListAsync();

        return entities.Select(entity => ItemMapper.ToModel(
            entity,
            flagEntities.Where(flag => flag.ItemId == entity.Id),
            gameTypeEntities.Where(gameType => gameType.ItemId == entity.Id),
            restrictionEntities.Where(restriction => restriction.ItemId == entity.Id),
            upgradePathEntities.Where(path => path.ItemId == entity.Id),
            detailsEntities.FirstOrDefault(details => details.ItemId == entity.Id),
            infusionSlotEntities.Where(slot => slot.ItemId == entity.Id),
            infusionSlotFlagEntities.Where(flag => flag.ItemId == entity.Id),
            statChoiceEntities.Where(choice => choice.ItemId == entity.Id),
            infixUpgradeAttributeEntities.Where(attribute => attribute.ItemId == entity.Id),
            extraRecipeEntities.Where(recipe => recipe.ItemId == entity.Id),
            unlockSkinEntities.Where(skin => skin.ItemId == entity.Id),
            vendorEntities.Where(vendor => vendor.ItemId == entity.Id),
            upgradeComponentFlagEntities.Where(flag => flag.ItemId == entity.Id),
            infusionUpgradeFlagEntities.Where(flag => flag.ItemId == entity.Id),
            upgradeComponentBonusEntities.Where(bonus => bonus.ItemId == entity.Id)));
    }

    public Task UpsertAsync(Item item) => UpsertAllAsync([item]);

    public Task UpsertAllAsync(IEnumerable<Item> items) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var item in items)
        {
            connection.InsertOrReplace(ItemMapper.ToItemEntity(item));

            connection.Table<ItemFlagEntity>().Delete(flag => flag.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToFlagEntities(item));

            connection.Table<ItemGameTypeEntity>().Delete(gameType => gameType.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToGameTypeEntities(item));

            connection.Table<ItemRestrictionEntity>().Delete(restriction => restriction.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToRestrictionEntities(item));

            connection.Table<ItemUpgradePathEntity>().Delete(path => path.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToUpgradePathEntities(item));

            connection.Table<ItemDetailsEntity>().Delete(details => details.ItemId == item.Id);
            var detailsEntity = ItemMapper.ToDetailsEntity(item);
            if (detailsEntity is not null)
            {
                connection.Insert(detailsEntity);
            }

            connection.Table<ItemInfusionSlotEntity>().Delete(slot => slot.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToInfusionSlotEntities(item));

            connection.Table<ItemInfusionSlotFlagEntity>().Delete(flag => flag.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToInfusionSlotFlagEntities(item));

            connection.Table<ItemStatChoiceEntity>().Delete(choice => choice.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToStatChoiceEntities(item));

            connection.Table<ItemInfixUpgradeAttributeEntity>().Delete(attribute => attribute.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToInfixUpgradeAttributeEntities(item));

            connection.Table<ItemExtraRecipeEntity>().Delete(recipe => recipe.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToExtraRecipeEntities(item));

            connection.Table<ItemUnlockSkinEntity>().Delete(skin => skin.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToUnlockSkinEntities(item));

            connection.Table<ItemVendorEntity>().Delete(vendor => vendor.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToVendorEntities(item));

            connection.Table<ItemUpgradeComponentFlagEntity>().Delete(flag => flag.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToUpgradeComponentFlagEntities(item));

            connection.Table<ItemInfusionUpgradeFlagEntity>().Delete(flag => flag.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToInfusionUpgradeFlagEntities(item));

            connection.Table<ItemUpgradeComponentBonusEntity>().Delete(bonus => bonus.ItemId == item.Id);
            connection.InsertAll(ItemMapper.ToUpgradeComponentBonusEntities(item));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<ItemFlagEntity>().Delete(flag => flag.ItemId == id);
        connection.Table<ItemGameTypeEntity>().Delete(gameType => gameType.ItemId == id);
        connection.Table<ItemRestrictionEntity>().Delete(restriction => restriction.ItemId == id);
        connection.Table<ItemUpgradePathEntity>().Delete(path => path.ItemId == id);
        connection.Table<ItemDetailsEntity>().Delete(details => details.ItemId == id);
        connection.Table<ItemInfusionSlotEntity>().Delete(slot => slot.ItemId == id);
        connection.Table<ItemInfusionSlotFlagEntity>().Delete(flag => flag.ItemId == id);
        connection.Table<ItemStatChoiceEntity>().Delete(choice => choice.ItemId == id);
        connection.Table<ItemInfixUpgradeAttributeEntity>().Delete(attribute => attribute.ItemId == id);
        connection.Table<ItemExtraRecipeEntity>().Delete(recipe => recipe.ItemId == id);
        connection.Table<ItemUnlockSkinEntity>().Delete(skin => skin.ItemId == id);
        connection.Table<ItemVendorEntity>().Delete(vendor => vendor.ItemId == id);
        connection.Table<ItemUpgradeComponentFlagEntity>().Delete(flag => flag.ItemId == id);
        connection.Table<ItemInfusionUpgradeFlagEntity>().Delete(flag => flag.ItemId == id);
        connection.Table<ItemUpgradeComponentBonusEntity>().Delete(bonus => bonus.ItemId == id);
        connection.Delete<ItemEntity>(id);
    });
}
