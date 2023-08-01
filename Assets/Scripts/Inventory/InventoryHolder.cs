using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryHolder : IPlayerInventoryHolder, IInitializable
{
    private IPlayerInventory _playerInventory;
    private IUIBuilder _uIBuilder;
    private IPlayerInput _playerInput;

    public IPlayerInventory PlayerInventory => _playerInventory;



    [Inject]
    public void Construct(IUIBuilder uIBuilder, IPlayerInput playerInput)
    {
        _uIBuilder = uIBuilder;
        _playerInput = playerInput;
    }

    public void Initialize()
    {
        _playerInput.InventoryButtonPressed += OnInventoryButtonPressed;
    }
    private void OnInventoryButtonPressed()
    {
        if (IsAlreadyInventoryOpened() == true)
        {
            _playerInventory.Close();
            _playerInventory = null;
            return;
        }
        _playerInventory = _uIBuilder.CreatePlayerInventory();
        _playerInput.ShowMouse();
    }
    private bool IsAlreadyInventoryOpened()
    {
        return _playerInventory != null;
    }
}