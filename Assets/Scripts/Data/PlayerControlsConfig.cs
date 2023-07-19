using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "PlayerControlsConfig", menuName = "Data/Player/PlayerControlsConfig", order = 1)]
public class PlayerControlsConfig : ScriptableObject
{
    public float sideSpeed;
    public float forwardSpeed;

    public float mouseHorizontalSensitivity;
    public float mouseVerticalSensitivity;

    public Clamps mouseVerticalClamp;
}
