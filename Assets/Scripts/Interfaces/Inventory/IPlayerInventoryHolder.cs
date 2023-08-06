using UnityEngine;

public interface IPlayerInventoryHolder
{
    IPlayerInventory PlayerInventory { get; }
}
public interface IItemsDragger
{
    void SetCanvasForItemsDragger(Canvas canvas);
    void AddItem(InventoryItem inventoryItem, InventoryCell inventoryCell);
    void UnDrugged(InventoryCell inventoryCell);
}