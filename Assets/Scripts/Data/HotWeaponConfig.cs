using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HotWeaponConfig", menuName = "Data/Weapons/HotWeaponConfig", order = 1)]
public class HotWeaponConfig : ScriptableObject
{
    public Bullet bulletPrefab;
    public int damage;
    public int force;
    public int bulletsCount;
    public float reloadSpeed;
}
