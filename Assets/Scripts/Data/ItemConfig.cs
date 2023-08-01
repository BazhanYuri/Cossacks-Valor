using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Data/Item")]
public class ItemConfig : ScriptableObject
{
    public Sprite icon;
    public float weight;
    public int width;
    public int height;
}

