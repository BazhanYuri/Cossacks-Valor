using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotWeapon : MonoBehaviour, IHotWeapon
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private HotWeaponConfig _config;

    private int _maxBulletsCount;
    private int _allAmmo = 100;
    private int _currentAmmo;
    private bool _isReloading;

    public Transform Transform => transform;




    private void Start()
    {
        _maxBulletsCount  = _config.maxBulletsCount;
    }
    public void Reload()
    {
        if (IsHaveMaximumBullets() == false && _isReloading == false)
        {
            StartCoroutine(Reloading());
        }
    }
    public void Attack()
    {
        if (IsHaveBullets())
        {
            Shoot();
        }
        else
        {
            Reload();
        }
    }
    private void Shoot()
    {
        IBullet bullet = Instantiate(_config.bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.Push(_config.force);
        _currentAmmo--;
    }
    private bool IsHaveMaximumBullets()
    {
        return _currentAmmo == _config.maxBulletsCount;
    }
    private bool IsHaveBullets()
    {
        return _currentAmmo > 0;
    }
    private IEnumerator Reloading()
    {
        _isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(_config.reloadTime);
        _currentAmmo = _maxBulletsCount;
        _isReloading = false;
        Debug.Log("Reloaded");
    }
}
