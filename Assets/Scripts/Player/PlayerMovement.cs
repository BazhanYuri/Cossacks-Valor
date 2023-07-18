using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class PlayerMovement : IPlayerMovement, IInitializable, ITickable
{
    private Player _player;
    private IPlayerInput _playerInput;

    private Vector2 _movementVector;


    public event Action<Vector2> PlayerMoved;



    [Inject]
    public void Construct(IPlayerInput playerInput)
    {
        _playerInput = playerInput;
    }
    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void Initialize()
    {
        _playerInput.PlayerMoved += Move;
    }

    public void Move(Vector2 value)
    {
        _movementVector = value;
    }

    public void Tick()
    {
        Vector3 moveVector = _player.transform.TransformDirection(
        new Vector3(_movementVector.x, 0, _movementVector.y));
        _player.Rigidbody.velocity = moveVector * 2;
        PlayerMoved?.Invoke(_movementVector);
    }
}
