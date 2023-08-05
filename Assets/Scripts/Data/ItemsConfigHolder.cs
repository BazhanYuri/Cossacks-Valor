using UnityEngine;

[CreateAssetMenu (fileName = "ItemsConfigHolder", menuName = "Data/ItemsConfigHolder")]
public class ItemsConfigHolder : ScriptableObject
{
    public ItemConfig[] items;
}