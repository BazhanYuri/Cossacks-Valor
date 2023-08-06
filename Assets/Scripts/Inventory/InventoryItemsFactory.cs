using UnityEngine;
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

    public RectTransform CreateTempView(GameObject prefab)
    {
        RectTransform tempView = GameObject.Instantiate(prefab).GetComponent<RectTransform>();

        return tempView;
    }

    private ItemConfig GetItemConfig(InventoryItemData itemData)
    {
        return _itemsConfigHolder.items[itemData.index];
    }
}
