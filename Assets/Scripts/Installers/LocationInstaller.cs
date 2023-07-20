using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private HotWeapon _hotWeaponPrefab;
    [Header("Configs")]
    [SerializeField] private PlayerControlsConfig _playerControlsConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindFactories();
        BindPlayer();
        BindWeaponHandler();
        BindInput();
        BindMovement();

        BindWeapon();
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
    private void BindWeaponHandler()
    {
        Container.BindInterfacesTo<PlayerWeaponHandler>().AsSingle();
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
    private void BindWeapon()
    {
        Container.BindInterfacesTo<HotWeapon>().FromComponentInNewPrefab(_hotWeaponPrefab).AsSingle();
    }
    
}

