using UnityEngine;
using System;
using Zenject;
using UnityEngine.InputSystem;

public class PlayerInput : IPlayerInput, IInitializable
{
    private PlayerInputAction _inputActions;


    public event Action<Vector2> PlayerMoved;
    public event Action<Vector2> PlayerLooked;
    public event Action InventoryButtonPressed;
    public event Action InteractButtonPressed;
    public event Action ShootButtonPressed;
    public event Action ReloadButtonPressed;

    public void Initialize()
    {
        _inputActions  = new PlayerInputAction();
        _inputActions.Enable();
        _inputActions.ActionMap.Movement.performed += OnMoved;
        _inputActions.ActionMap.Movement.canceled += OnMoved;

        _inputActions.ActionMap.Look.performed += OnLooked;
        _inputActions.ActionMap.Look.canceled += OnLooked;

        _inputActions.ActionMap.Inventory.started += InvokeInventoryPressed;
        _inputActions.ActionMap.Interact.started += InvokeInteractButtonPressed;
        _inputActions.ActionMap.Shoot.started += InvokeShootButtonPressed;
        _inputActions.ActionMap.Reload.started += InvokeReloadButtonPressed;
    }

    private void OnMoved(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        InvokePlayerMoved(input);
    }
    private void OnLooked(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        InvokePlayerLooked(input);
    }
    public void InvokePlayerMoved(Vector2 value)
    {
        PlayerMoved?.Invoke(value);
    }
    public void InvokePlayerLooked(Vector2 value)
    {
        PlayerLooked?.Invoke(value);
    }

    public void InvokeInventoryPressed(InputAction.CallbackContext context)
    {
        InventoryButtonPressed?.Invoke();
    }

    public void InvokeInteractButtonPressed(InputAction.CallbackContext context)
    {
        InteractButtonPressed?.Invoke();
    }
    public void InvokeShootButtonPressed(InputAction.CallbackContext context)
    {
        ShootButtonPressed?.Invoke();
    }
    public void InvokeReloadButtonPressed(InputAction.CallbackContext context)
    {
        ReloadButtonPressed?.Invoke();
    }
}

