using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [Header("Configs")]
    [SerializeField] private PlayerControlsConfig _playerControlsConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindFactories();
        BindPlayer();
        BindInput();
        BindMovement();
    }

    private void BindConfigs()
    {
        Container.BindInstance(_playerControlsConfig).AsSingle();
    }
    private void BindFactories()
    {
        Container.BindFactory<Player, PlayerFactory>().FromComponentInNewPrefab(_playerPrefab);
    }
    private void BindPlayer()
    {
        Container.BindInterfacesTo<PlayerFactory>().FromResolve();
    }
    private void BindInput()
    {
        Container.BindInterfacesTo<PlayerInput>().AsSingle();
        Container.BindInterfacesTo<PlayerLooker>().AsSingle();
    }
    private void BindMovement()
    {
        Container.BindInterfacesTo<PlayerMovement>().AsSingle();
    }
    
}

