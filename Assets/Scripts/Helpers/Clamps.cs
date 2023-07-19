using System;
using UnityEngine;

[Serializable]
public class Clamps
{
    public float min;
    public float max;

    public Clamps(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public float Clamp(float value)
    {
        return Mathf.Clamp(value, min, max);
    }
}
