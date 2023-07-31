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
    public InventoryModel Create()
    {
        InventoryView inventoryView = base.Create();
        InventoryModel inventoryModel = new InventoryModel(inventoryView);

        return inventoryModel;
    }
}
