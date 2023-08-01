using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _cellContent;
    [SerializeField] private Transform _cellPrefab;
    


    public void CreateInventory(int width, int height)
    {
        _cellContent.constraintCount = width;

        for (int i = 0; i < width * height; i++)
        {
            var cell = Instantiate(_cellPrefab, _cellContent.transform);
            cell.name = $"Cell {i}";
        }
    }
}
