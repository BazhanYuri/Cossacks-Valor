using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;


public class PlayerHolder : IInitializable
{
    private PlayerFactory _factory;
    private Transform _spawnPoint;


    [Inject]
    public void Construct(PlayerFactory playerFactory)
    {
        _factory = playerFactory;
    }
    public PlayerHolder(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
    public void Initialize()
    {
        Player player = _factory.Create();
        player.transform.position = _spawnPoint.position + new Vector3(0, 2, 0);
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
