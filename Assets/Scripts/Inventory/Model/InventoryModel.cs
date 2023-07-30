using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryModel : IInventoryModel
{
    private InventoryView _inventoryView;
    

    public InventoryModel(InventoryView inventoryView)
    {
        _inventoryView = inventoryView;
    }
}
