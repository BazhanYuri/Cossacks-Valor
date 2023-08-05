using UnityEngine;
using Zenject;

public class UIBuilder : IUIBuilder
{
    private InventoryFactory _inventoryFactory;


    [Inject]
    public void Construct(InventoryFactory inventoryFactory)
    {
        _inventoryFactory = inventoryFactory;
    }
    public InventoryModel CreatePlayerInventory()
    {
        return _inventoryFactory.Create();
    }
}
public class UIFactory
{

}
public class InventoryFactory : PlaceholderFactory<InventoryView>
{
    private PlayerInventoryConfig _playerInventoryConfig;
    private IInventoryItemFactory _inventoryItemFactory;
    private IDatabase _database;

    [Inject]
    public void Construct(PlayerInventoryConfig playerInventoryConfig, IInventoryItemFactory inventoryItemFactory, IDatabase database)
    {
        _playerInventoryConfig = playerInventoryConfig;
        _inventoryItemFactory = inventoryItemFactory;
        _database = database;
    }
    public InventoryModel Create()
    {
        InventoryView inventoryView = base.Create();
        InventoryModel inventoryModel = new InventoryModel(inventoryView, _inventoryItemFactory, _playerInventoryConfig, _database);
        inventoryModel.Initialize();

        return inventoryModel;
    }
}
