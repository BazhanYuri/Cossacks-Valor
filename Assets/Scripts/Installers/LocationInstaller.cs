using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;

    public override void InstallBindings()
    {
        BindFactories();
        BindPlayer();
        BindInput();
        BindMovement();
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
    }
    private void BindMovement()
    {
        Container.BindInterfacesTo<PlayerMovement>().AsSingle();
    }
}

