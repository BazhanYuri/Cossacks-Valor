using UnityEngine;
using System;
using Zenject;
using UnityEngine.InputSystem;

public class PlayerInput : IPlayerInput, IInitializable
{
    private PlayerInputAction _inputActions;

    private bool _isInputBlocked = false;

    public event Action<Vector2> PlayerMoved;
    public event Action<Vector2> PlayerLooked;
    public event Action InventoryButtonPressed;
    public event Action InteractButtonPressed;
    public event Action ShootButtonPressed;
    public event Action ReloadButtonPressed;
    public event Action JumpButtonPressed;


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
        _inputActions.ActionMap.Jump.started += InvokeJumpButtonPressed;
    }

    
    public void ShowMouse()
    {
        UnBlockMouse();
    }
    public void HideMouse()
    {
        BlockMouse();
    }
    public void InvokePlayerMoved(Vector2 value)
    {
        if (_isInputBlocked == true)
        {
            return;
        }
        PlayerMoved?.Invoke(value);
    }
    private void InvokePlayerLooked(Vector2 value)
    {
        if (_isInputBlocked == true)
        {
            return;
        }
        PlayerLooked?.Invoke(value);
    }

    private void InvokeInventoryPressed(InputAction.CallbackContext context)
    {
        InventoryButtonPressed?.Invoke();
    }
    private void InvokeInteractButtonPressed(InputAction.CallbackContext context)
    {
        if (_isInputBlocked == true)
        {
            return;
        }
        InteractButtonPressed?.Invoke();
    }
    private void InvokeShootButtonPressed(InputAction.CallbackContext context)
    {
        if (_isInputBlocked == true)
        {
            return;
        }
        ShootButtonPressed?.Invoke();
    }
    private void InvokeReloadButtonPressed(InputAction.CallbackContext context)
    {
        ReloadButtonPressed?.Invoke();
    }
    private void InvokeJumpButtonPressed(InputAction.CallbackContext context)
    {
        JumpButtonPressed?.Invoke();
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
    private void UnBlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _isInputBlocked = true;
    }
    private void BlockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _isInputBlocked = false;
    }
}

