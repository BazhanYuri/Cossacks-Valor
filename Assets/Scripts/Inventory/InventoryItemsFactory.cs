using Zenject;

public class InventoryItemsFactory : IInventoryItemFactory
{
    private ItemsConfigHolder _itemsConfigHolder;


    [Inject]
    public void Construct(ItemsConfigHolder itemsConfigHolder)
    {
        _itemsConfigHolder = itemsConfigHolder;
    }
    public InventoryItem Create(InventoryItemData itemData)
    {
        return new InventoryItem(GetItemConfig(itemData), itemData.xPos, itemData.yPos);
    }
    private ItemConfig GetItemConfig(InventoryItemData itemData)
    {
        return _itemsConfigHolder.items[itemData.index];
    }
}
