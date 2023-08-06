using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private HotWeapon _hotWeaponPrefab;
    [Header("Configs")]
    [SerializeField] private PlayerControlsConfig _playerControlsConfig;
    [Header("UI")]
    [SerializeField] private InventoryView _inventoryViewPrefab;


    public override void InstallBindings()
    {
        BindConfigs();
        BindFactories();
        BindPlayerHolder();
        BindInventoryHolder();
        BindItemsDrugger();
        BindWeaponHandler();
        BindInput();
        BindMovement();
        BindWeapon();
        BindUIBuilder();
    }

    private void BindConfigs()
    {
        Container.BindInstance(_playerControlsConfig).AsSingle();
    }
    private void BindFactories()
    {
        Container.BindFactory<Player, PlayerFactory>().FromComponentInNewPrefab(_playerPrefab);
        Container.BindFactory<InventoryView, InventoryFactory>().FromComponentInNewPrefab(_inventoryViewPrefab);
        Container.BindInterfacesTo<InventoryItemsFactory>().AsSingle();
    }
    private void BindPlayerHolder()
    {
        Container.BindInterfacesTo<PlayerHolder>().AsSingle();
    }
    private void BindInventoryHolder()
    {
        Container.BindInterfacesTo<InventoryHolder>().AsSingle();
    }
    private void BindItemsDrugger()
    {
        Container.BindInterfacesTo<ItemsDragger>().AsSingle();
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
    private void BindUIBuilder()
    {
        Container.BindInterfacesTo<UIBuilder>().AsSingle();
    }

}

