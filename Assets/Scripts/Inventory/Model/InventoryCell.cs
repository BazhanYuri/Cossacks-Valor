using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IBeginDragHandler, IDropHandler
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _itemIcon;

    private IItemsDragger _itemsDragger;
    private InventoryItem _inventoryItem;
    private GameObject _itemView;

    private int _x;
    private int _y;
    public int X { get => _x; set => _x = value; }
    public int Y { get => _y; set => _y = value; }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsCanDrugItem())
        {
            _itemsDragger.AddItem(_inventoryItem, this);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        _itemsDragger.UnDrugged(this);
    }
    public void Initialize(int x, int y, IItemsDragger itemsDragger)
    {
        _x = x;
        _y = y;
        _itemsDragger = itemsDragger;
    }
    public bool IsEmpty()
    {
        return _inventoryItem == null;
    }
    public void ClearCell()
    {
        Destroy(_itemView.gameObject);
        _inventoryItem = null;
    }
    public void SetItemCell(InventoryItem inventoryItem)
    {
        _inventoryItem = inventoryItem;

        SpawnView(inventoryItem.prefab);
    }
    private void SpawnView(GameObject itemViewPrefab)
    {
        _itemView = Instantiate(itemViewPrefab, _rectTransform);
    }
    private bool IsCanDrugItem()
    {
        return _inventoryItem != null;
    }

    
}
public class InventoryItem
{
    public Sprite icon;
    public GameObject prefab;
    public float weight;
    public int xPosition;
    public int yPosition;

    public InventoryItem(ItemConfig itemConfig, int xPosition, int yPosition)
    {
        icon = itemConfig.icon;
        prefab = itemConfig.prefab;
        weight = itemConfig.weight;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
    }
}
