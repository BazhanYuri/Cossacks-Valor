using UnityEngine;
using UnityEngine.UI;
public class InventoryView : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _cellContent;
    [SerializeField] private InventoryCell _cellPrefab;
    [SerializeField] private RectTransform _cellsRoot;

    private InventoryCell[] _cells;

    private int _width;
    private int _height;
    private float _cellSize;



    private void Awake()
    {
        _cellSize = _cellContent.cellSize.x;
    }
    public void ShowInventory(int width, int height)
    {
        _width = width;
        _height = height;
        _cellContent.constraintCount = width;
        _cells = new InventoryCell[width * height];

        int pointer = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var cell = Instantiate(_cellPrefab, _cellContent.transform);
                cell.name = $"Cell {i}";
                cell.Initialize(i, j);
                _cells[pointer] = cell;

                pointer++;
            }
        }
        SetInventorySize();
    }
    public void AddItem(InventoryItem inventoryItem)
    {
        int lenght = _cells.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (_cells[i].X == inventoryItem.xPosition && _cells[i].Y == inventoryItem.yPosition)
            {
                _cells[i].SetItemCell(inventoryItem);
                break;
            }
        }
    }
    private void SetInventorySize()
    {
        _cellsRoot.sizeDelta = new Vector2(_width * _cellSize, _height * _cellSize);
    }
}
