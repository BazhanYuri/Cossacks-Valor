using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _itemIcon;
    
    private int _x;
    private int _y;

    public int X { get => _x; set => _x = value; }
    public int Y { get => _y; set => _y = value; }

    public void Initialize(int x, int y)
    {
        _x = x;
        _y = y;
    }
    public void SetItemCell(InventoryItem inventoryItem)
    {
        _itemIcon.sprite = inventoryItem.icon;
    }
}
public class InventoryItem
{
    public Sprite icon;
    public float weight;
    public int xPosition;
    public int yPosition;

    public InventoryItem(ItemConfig itemConfig, int xPosition, int yPosition)
    {
        icon = itemConfig.icon;
        weight = itemConfig.weight;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
    }
}
