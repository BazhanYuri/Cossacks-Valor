using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public interface IMovementInput
{
    public event Action<Vector2> PlayerMoved;
}
public interface ILookerInput
{
    public event Action<Vector2> PlayerLooked;
}
public interface IShootInput
{
    public event Action ShootButtonPressed;
    public event Action ReloadButtonPressed;
}
public interface IJumpInput
{
    public event Action JumpButtonPressed;
}

public interface IPlayerInput : IMovementInput, ILookerInput, IShootInput, IJumpInput
{
    public event Action InventoryButtonPressed;
    public event Action InteractButtonPressed;
    

    void ShowMouse();
    void HideMouse();
}
