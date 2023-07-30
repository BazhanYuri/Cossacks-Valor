using UnityEngine;
using Zenject;

public class UIBuilder : IUIBuilder
{
    public void CreatePlayerInventory()
    {

    }
}
public class UIFactory
{

}
public class InventoryFactory : PlaceholderFactory<InventoryView>
{
    public override InventoryView Create()
    {
        InventoryView inventoryView = base.Create();
        InventoryModel inventoryModel = new InventoryModel(inventoryView);

        return inventoryView;
    }
}
