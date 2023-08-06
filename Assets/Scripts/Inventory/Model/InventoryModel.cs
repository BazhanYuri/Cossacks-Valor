using UnityEngine;
using Zenject;

public class ItemsDragger : IItemsDragger, ITickable
{
    private IInventoryItemFactory _inventoryItemsFactory;
    private InventoryCell _currentCell;
    private InventoryItem _druggedItem;

    private Canvas _canvas;
    private RectTransform _tempView;
    private bool _isDrugging = false;


    [Inject]
    public void Construct(IInventoryItemFactory inventoryItemsFactory)
    {
        _inventoryItemsFactory = inventoryItemsFactory;
    }
    public void SetCanvasForItemsDragger(Canvas canvas)
    {
        _canvas = canvas;
    }
    public void AddItem(InventoryItem inventoryItem, InventoryCell inventoryCell)
    {
        _druggedItem = inventoryItem;
        _currentCell = inventoryCell;
    }
    public void UnDrugged(InventoryCell inventoryCell)
    {
        MoveItemToAnotherCellIfEmpty(inventoryCell);
    }

    public void Tick()
    {
        MoveIfHaveItem();
    }
    private void MoveIfHaveItem()
    {
        if (IsHaveItem() == false)
        {
            return;
        }

        if (_isDrugging == false)
        {
            _tempView = _inventoryItemsFactory.CreateTempView(_druggedItem.prefab);
            _tempView.parent = _canvas.transform;
            _isDrugging = true;
        }
        _tempView.position = Input.mousePosition;
    }
    private bool IsHaveItem()
    {
        return _druggedItem != null;
    }
    private void MoveItemToAnotherCellIfEmpty(InventoryCell inventoryCell)
    {
        if (inventoryCell.IsEmpty() == true)
        {
            MoveToCell(inventoryCell);
        }

        _isDrugging = false;
        _druggedItem = null;
        Object.Destroy(_tempView.gameObject);
    }
    private void MoveToCell(InventoryCell inventoryCell)
    {
        inventoryCell.SetItemCell(_druggedItem);
        _currentCell.ClearCell();
        _currentCell = null;
    }

}
public class InventoryModel : IPlayerInventory
{
    private IDatabase _database;
    private IInventoryItemFactory _inventoryItemsFactory;
    private IItemsDragger _itemsDragger;    
    private InventoryView _inventoryView;
    private PlayerInventoryConfig _playerInventoryConfig;

    private InventoryItem[] _inventoryItems;


    public InventoryModel(InventoryView inventoryView, IInventoryItemFactory inventoryItemsFactory, PlayerInventoryConfig playerInventoryConfig, IDatabase database, IItemsDragger itemsDragger)
    {
        _inventoryView = inventoryView;
        _playerInventoryConfig = playerInventoryConfig;
        _inventoryItemsFactory = inventoryItemsFactory;
        _database = database;
        _itemsDragger = itemsDragger;

    }
    public void Initialize()
    {
        _itemsDragger.SetCanvasForItemsDragger(_inventoryView.Canvas);
        FillInventory();
        _inventoryView.ShowInventory(_playerInventoryConfig.inventoryWidth, _playerInventoryConfig.inventoryHeight, _itemsDragger);
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
