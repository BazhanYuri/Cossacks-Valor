using UnityEngine;
using Zenject;

public class PlayerWeaponHandler : IPlayerWeaponHandler, IInitializable
{
    private IWeapon _currentWeapon;
    private IShootInput _playerInput;
    private Player _player;



    [Inject]
    public void Construct(IWeapon currentWeapon, IShootInput playerInput)
    {
        _currentWeapon = currentWeapon;
        _playerInput = playerInput;
    }

    public void Initialize()
    {
        _playerInput.ShootButtonPressed += PerformAttack;
        _playerInput.ReloadButtonPressed += ReloadWeapon;

        EquipWeapon(_currentWeapon);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
    public void EquipWeapon(IWeapon weapon)
    {
        _currentWeapon = weapon;
        _currentWeapon.Transform.SetParent(_player.Hand);
        _currentWeapon.Transform.localPosition = Vector3.zero;
    }
    private void ReloadWeapon()
    {
        if (_currentWeapon is IHotWeapon hotWeapon)
        {
            hotWeapon.Reload();
        }
    }
    private void PerformAttack()
    {
        _currentWeapon.Attack();
    }
}
