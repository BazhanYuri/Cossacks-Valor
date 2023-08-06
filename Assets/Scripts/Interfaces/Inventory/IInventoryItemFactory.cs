using UnityEngine;

public interface IInventoryItemFactory
{
    InventoryItem Create(InventoryItemData itemConfig);
    RectTransform CreateTempView(GameObject prefab);
}
