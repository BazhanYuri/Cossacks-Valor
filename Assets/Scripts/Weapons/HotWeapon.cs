using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotWeapon : MonoBehaviour, IHotWeapon
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private HotWeaponConfig _config;

    public Transform Transform => transform;


    public void Reload()
    {

    }
    public void Attack()
    {
        IBullet bullet = Instantiate(_config.bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.Push(_config.force);
    }
}
