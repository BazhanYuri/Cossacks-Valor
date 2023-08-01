using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventoryItem
{
    private int _x;
    private int _y;

    public int X { get => _x; set => _x = value; }
    public int Y { get => _y; set => _y = value; }

    public InventoryItem(int x, int y)
    {
        x = _x;
        y = _y;
    }
}
public class InventoryModel : IPlayerInventory
{
    private InventoryView _inventoryView;
    

    public InventoryModel(InventoryView inventoryView)
    {
        _inventoryView = inventoryView;
    }
    public void Initialize()
    {
        _inventoryView.CreateInventory(3, 5);
    }
    public void Close()
    {
        Object.Destroy(_inventoryView.gameObject);
    }
}
