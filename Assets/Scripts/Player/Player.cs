using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;


public class PlayerHolder : IInitializable
{
    private PlayerFactory _factory;


    [Inject]
    public void Construct(PlayerFactory playerFactory)
    {
        _factory = playerFactory;
    }

    public void Initialize()
    {
        _factory.Create();
    }
}
public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _hand;

    private IPlayerWeaponHandler _playerWeaponHandler;
    private IPlayerMovement _playerMovement;
    private IPlayerLooker _playerLooker;
    private IPlayerInput _playerInput;


    public Rigidbody Rigidbody { get => _rigidbody;}
    public Camera Camera { get => _camera;}
    public Transform Hand { get => _hand;}


    [Inject]
    public void Construct(IPlayerMovement playerMovement, IPlayerLooker playerLooker, IPlayerInput playerInput, IPlayerWeaponHandler playerWeaponHandler)
    {
        _playerMovement = playerMovement;
        _playerLooker = playerLooker;
        _playerInput = playerInput;
        _playerWeaponHandler = playerWeaponHandler;
    }


    private void Awake()
    {
        _playerMovement.SetPlayer(this);
        _playerLooker.SetPlayer(this);
        _playerWeaponHandler.SetPlayer(this);
    }
}
