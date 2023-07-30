using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public float weight;
    public int width;
    public int height;
}

