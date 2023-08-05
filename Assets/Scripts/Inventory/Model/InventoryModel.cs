using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class InventoryModel : IPlayerInventory
{
    private IDatabase _database;
    private IInventoryItemFactory _inventoryItemsFactory;
    private InventoryView _inventoryView;
    private PlayerInventoryConfig _playerInventoryConfig;

    private InventoryItem[] _inventoryItems;


    public InventoryModel(InventoryView inventoryView, IInventoryItemFactory inventoryItemsFactory, PlayerInventoryConfig playerInventoryConfig, IDatabase database)
    {
        _inventoryView = inventoryView;
        _playerInventoryConfig = playerInventoryConfig;
        _inventoryItemsFactory = inventoryItemsFactory;
        _database = database;
    }
    public void Initialize()
    {
        FillInventory();
        _inventoryView.ShowInventory(_playerInventoryConfig.inventoryWidth, _playerInventoryConfig.inventoryHeight);
        ShowItemsInInventory();
    }
    private void FillInventory()
    {
        int countOfItems = _database.CurrentSlot.gameSave.inventoryItemsData.Length;
        _inventoryItems = new InventoryItem[countOfItems];

        for (int i = 0; i < countOfItems; i++)
        {
            _inventoryItems[i] = _inventoryItemsFactory.Create(_database.CurrentSlot.gameSave.inventoryItemsData[i]);
        }
    }
    private void ShowItemsInInventory()
    {
        for (int i = 0; i < _inventoryItems.Length; i++)
        {
            _inventoryView.AddItem(_inventoryItems[i]);
        }
    }
    public void Close()
    {
        Object.Destroy(_inventoryView.gameObject);
    }
}
