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
    private bool _isGrounded;
    private bool _isJumping;

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
        _playerInput.JumpButtonPressed += Jump;
    }
    public void Move(Vector2 value)
    {
        _movementVector = value;
    }

    public void Tick()
    {
        Move();
        CheckIsGrounded();

        PlayerMoved?.Invoke(_movementVector);
    }
    private void Move()
    {
        Vector3 moveVector = _player.transform.TransformDirection(
        new Vector3(_movementVector.x * _playerControlsConfig.sideSpeed, _player.Rigidbody.velocity.y, _movementVector.y * _playerControlsConfig.forwardSpeed));

        _player.Rigidbody.velocity = moveVector;
    }
    private void CheckIsGrounded()
    {
        _isGrounded = Physics.Raycast(_player.transform.position, Vector3.down, _playerControlsConfig.groundCheckDistance);
    }
    private void Jump()
    {
        if (CheckIsCanJump() == false)
        {
            return;
        }
        _isJumping = true;
        _player.Rigidbody.AddForce(Vector3.up * _playerControlsConfig.jumpForce, ForceMode.Impulse);
    }
    private bool CheckIsCanJump()
    {
        return _isGrounded;
    }
}
