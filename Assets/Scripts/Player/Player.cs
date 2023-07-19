using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody _rigidbody;

    private IPlayerMovement _playerMovement;
    private IPlayerLooker _playerLooker;
    private IPlayerInput _playerInput;

    public Rigidbody Rigidbody { get => _rigidbody;}
    public Camera Camera { get => _camera;}


    [Inject]
    public void Construct(IPlayerMovement playerMovement, IPlayerLooker playerLooker, IPlayerInput playerInput)
    {
        _playerMovement = playerMovement;
        _playerLooker = playerLooker;
        _playerInput = playerInput;
    }


    private void Awake()
    {
        _playerMovement.SetPlayer(this);
        _playerLooker.SetPlayer(this);
    }
}
