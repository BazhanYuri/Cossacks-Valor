using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private IPlayerMovement _playerMovement;
    private IPlayerInput _playerInput;

    public Rigidbody Rigidbody { get => _rigidbody;}


    [Inject]
    public void Construct(IPlayerMovement playerMovement, IPlayerInput playerInput)
    {
        _playerMovement = playerMovement;
        _playerInput = playerInput;
    }


    private void Awake()
    {
        _playerMovement.SetPlayer(this);
    }
}
