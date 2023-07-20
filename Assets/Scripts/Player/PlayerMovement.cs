using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class PlayerMovement : IPlayerMovement, IInitializable, ITickable
{
    private Player _player;
    private PlayerControlsConfig _playerControlsConfig;
    private IPlayerInput _playerInput;

    private Vector2 _movementVector;


    public event Action<Vector2> PlayerMoved;



    [Inject]
    public void Construct(IPlayerInput playerInput, PlayerControlsConfig playerControlsConfig)
    {
        _playerInput = playerInput;
        _playerControlsConfig = playerControlsConfig;
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
        Move();

        PlayerMoved?.Invoke(_movementVector);
    }
    private void Move()
    {
        Vector3 moveVector = _player.transform.TransformDirection(
        new Vector3(_movementVector.x * _playerControlsConfig.sideSpeed, _player.Rigidbody.velocity.y, _movementVector.y * _playerControlsConfig.forwardSpeed));

        _player.Rigidbody.velocity = moveVector;
    }
}
