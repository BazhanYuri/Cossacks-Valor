using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "PlayerControlsConfig", menuName = "Data/Player/PlayerControlsConfig", order = 1)]
public class PlayerControlsConfig : ScriptableObject
{
    [Header ("Movement")]
    public float sideSpeed;
    public float forwardSpeed;
    [Header ("Jump")]
    public float jumpForce;
    public float groundCheckDistance;
    [Header ("Mouse look")]
    public float mouseHorizontalSensitivity;
    public float mouseVerticalSensitivity;

    public Clamps mouseVerticalClamp;
}
