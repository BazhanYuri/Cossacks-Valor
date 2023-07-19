using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public interface IMovementInput
{
    public event Action<Vector2> PlayerMoved;
    void InvokePlayerMoved(Vector2 value);
}
public interface ILookerInput
{
    public event Action<Vector2> PlayerLooked;

    void InvokePlayerLooked(Vector2 value);
}

public interface IPlayerInput : IMovementInput, ILookerInput
{
    public event Action InventoryButtonPressed;
    public event Action InteractButtonPressed;
    void InvokeInventoryPressed(InputAction.CallbackContext context);
    void InvokeInteractButtonPressed(InputAction.CallbackContext context);
}
