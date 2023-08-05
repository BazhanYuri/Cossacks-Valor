using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [Header ("Configs")]
    [SerializeField] private PlayerInventoryConfig _playerInventoryConfig;
    [SerializeField] private ItemsConfigHolder _itemsConfigHolder;

    public override void InstallBindings()
    {
        BindConfigs();
        BindDataBase();
    }
    private void BindConfigs()
    {
        Container.BindInstance(_playerInventoryConfig).AsSingle();
        Container.BindInstance(_itemsConfigHolder).AsSingle();
    }
    private void BindDataBase()
    {
        Container.BindInterfacesTo<DataBase>().AsSingle();
    }
}

